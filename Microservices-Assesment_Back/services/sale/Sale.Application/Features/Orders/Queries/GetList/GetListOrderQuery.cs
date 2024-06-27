using AutoMapper;
using Azure.Core;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using MediatR;
using Sale.Application.Services.Repositories;
using Sale.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sale.Application.Features.Orders.Queries.GetList;

public class GetListOrderQuery : IRequest<GetListResponse<GetListOrderListItemDto>>
{
    public PageRequest PageRequest { get; set; }
}

public class GetListOrderQueryHandler : IRequestHandler<GetListOrderQuery, GetListResponse<GetListOrderListItemDto>>
{
    public readonly IOrderRepository _orderRepository;
    public readonly IMapper _mapper;

    public GetListOrderQueryHandler(IOrderRepository orderRepository, IMapper mapper)
    {
        _orderRepository = orderRepository;
        _mapper = mapper;
    }

    public async Task<GetListResponse<GetListOrderListItemDto>> Handle(GetListOrderQuery query, CancellationToken cancellationToken)
    {
        Paginate<Order> order = await _orderRepository.GetListAsync(
            index: query.PageRequest.PageIndex,
            size: query.PageRequest.PageSize,
            cancellationToken: cancellationToken
            );

        GetListResponse<GetListOrderListItemDto> response = _mapper.Map<GetListResponse<GetListOrderListItemDto>>(order);
        return response;
    }

}
