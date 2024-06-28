using Admin.Domain.DTOs;
using AutoMapper;
using Contracts.Request;
using Contracts.Responses;
using Core.Application.Responses;
using MassTransit;
using MediatR;

namespace Admin.Application.Features.EventBus;

public class GetOrderQuery : IRequest<GetOrderResponse>
{

}

public class GetOrderQueryHandler(
        IMapper mapper,
        IRequestClient<ShipperRequest> clientShipper,
        IRequestClient<SupplierRequest> clientSupplier,
        IRequestClient<OrderRequest> clientOrder,
        IRequestClient<SellerRequest> clientSeller
    ) : IRequestHandler<GetOrderQuery, GetOrderResponse>
{
    public readonly IMapper _mapper = mapper;
    private readonly IRequestClient<ShipperRequest> _clientShipper = clientShipper;
    private readonly IRequestClient<SupplierRequest> _clientSupplier = clientSupplier;
    private readonly IRequestClient<OrderRequest> _clientOrder = clientOrder;
    private readonly IRequestClient<SellerRequest> _clientSeller = clientSeller;



    public async Task<GetOrderResponse> Handle(GetOrderQuery request, CancellationToken cancellationToken)
    {

        Guid OrderId = new();
        var orderResponse = await _clientOrder.GetResponse<OrderResponse>(new { OrderId }, cancellationToken);


        var shipperResponse = _clientShipper.GetResponse<ShipperResponse>(new { Id = orderResponse.Message.ShipperID }, cancellationToken);
        var supplierResponse = _clientSupplier.GetResponse<SupplierResponse>(new { Id = orderResponse.Message.SupplierID }, cancellationToken);
        var sellerResponse = _clientSeller.GetResponse<SellerResponse>(new { Id = orderResponse.Message.SellerID }, cancellationToken);

        await Task.WhenAll(shipperResponse, supplierResponse, sellerResponse);

        var supplier = await supplierResponse; //supplierResponse bir response task cevap değil
        var shipper = await shipperResponse;
        var seller = await sellerResponse;


        var mappedSupplier = _mapper.Map<Supplier>(supplier.Message);
        var mappedShipper = _mapper.Map<Shipper>(shipper.Message);
        var mapperSeller = _mapper.Map<Seller>(seller.Message);

        var result = _mapper.Map<GetOrderResponse>(orderResponse.Message);

        result.Supplier = mappedSupplier;
        result.Shipper = mappedShipper;
        result.Seller = mapperSeller;

        return result;

    }
}

