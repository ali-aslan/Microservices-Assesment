using AutoMapper;
using MediatR;
using Sale.Application.Services.Repositories;
using Sale.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sale.Application.Features.Orders.Commands.Create;

public class CreateOrderCommand:IRequest<CreatedOrderResponse>
{
    public Guid CustomerID { get; set; }
    public Guid ProductID { get; set; }
    public Guid SupplierID { get; set; }
    public Guid ShipperID { get; set; }
    public Guid SellerID { get; set; }
}

public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand,CreatedOrderResponse>
{
    public readonly IOrderRepository _OrderRepository;
    public readonly IMapper _mapper;
    //public readonly OrdersBusinessRules _OrderBusinessRules;

    public CreateOrderCommandHandler(IOrderRepository OrderRepository, IMapper mapper/* ,OrdersBusinessRules OrderBusinessRules*/)
    {
        _OrderRepository = OrderRepository;
        _mapper = mapper;
        //_OrderBusinessRules = OrderBusinessRules;
    }

    public async Task<CreatedOrderResponse>? Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        //await _OrderBusinessRules.OrderNameCannotBeDuplicatedWhenInsterted(request.Name);

        Order order = _mapper.Map<Order>(request);
        order.Id = new Guid();

        await _OrderRepository.AddAsync(order);

        CreatedOrderResponse createdOrderResponse = _mapper.Map<CreatedOrderResponse>(order);
        return createdOrderResponse;

    }
}


