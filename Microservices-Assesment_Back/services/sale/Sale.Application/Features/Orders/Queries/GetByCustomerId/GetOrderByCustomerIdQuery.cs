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

namespace Sale.Application.Features.Orders.Queries.GetByCustomerId;

public class GetOrderByCustomerIdQuery:IRequest<GetOrderByCustomerIdResponse>
{
    public Guid CustomerId { get; set; }
}

public class GetOrderByCustomerIdQueryHandler : IRequestHandler<GetOrderByCustomerIdQuery, GetOrderByCustomerIdResponse>
{
    public readonly IOrderRepository _orderRepository;
    public readonly IMapper _mapper;

    public GetOrderByCustomerIdQueryHandler(IOrderRepository orderRepository, IMapper mapper)
    {
        _orderRepository = orderRepository;
        _mapper = mapper;
    }

    public async Task<GetOrderByCustomerIdResponse> Handle(GetOrderByCustomerIdQuery request, CancellationToken cancellationToken)
    {
       Order? order = await _orderRepository.GetAsync(predicate:o=>o.CustomerID == request.CustomerId,cancellationToken:cancellationToken);

        GetOrderByCustomerIdResponse response = _mapper.Map<GetOrderByCustomerIdResponse>(order);
        return response;
    }
}
