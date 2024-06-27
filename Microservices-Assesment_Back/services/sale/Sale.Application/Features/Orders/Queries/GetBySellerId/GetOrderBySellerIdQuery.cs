using AutoMapper;
using MediatR;
using Sale.Application.Services.Repositories;
using Sale.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Sale.Application.Features.Orders.Queries.GetBySellerId;

public class GetOrderBySellerIdQuery:IRequest<GetOrderBySellerIdResponse>
{
    public Guid SellerId { get; set; }
}

public class GetOrderBySellerIdQueryHandler : IRequestHandler<GetOrderBySellerIdQuery, GetOrderBySellerIdResponse>
{
    public readonly IOrderRepository _orderRepository;
    public readonly IMapper _mapper;

    public GetOrderBySellerIdQueryHandler(IOrderRepository orderRepository, IMapper mapper)
    {
        _orderRepository = orderRepository;
        _mapper = mapper;
    }

    public async Task<GetOrderBySellerIdResponse> Handle(GetOrderBySellerIdQuery request, CancellationToken cancellationToken)
    {
       Order? order = await _orderRepository.GetAsync(predicate:o=>o.SellerID == request.SellerId, cancellationToken:cancellationToken);

        GetOrderBySellerIdResponse response = _mapper.Map<GetOrderBySellerIdResponse>(order);
        return response;
    }
}
