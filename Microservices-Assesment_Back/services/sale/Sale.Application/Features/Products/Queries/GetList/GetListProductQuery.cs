using AutoMapper;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using MediatR;
using Sale.Application.Features.Orders.Queries.GetList;
using Sale.Application.Services.Repositories;
using Sale.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Sale.Application.Features.Products.Queries.GetList;

public class GetListProductQuery : IRequest<GetListResponse<GetListProductListItemDto>>
{
    public PageRequest PageRequest { get; set; }
}
public class GetListProductQueryHandler : IRequestHandler<GetListProductQuery, GetListResponse<GetListProductListItemDto>>
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    public GetListProductQueryHandler(IProductRepository productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }

    public async Task<GetListResponse<GetListProductListItemDto>> Handle(GetListProductQuery request, CancellationToken cancellationToken)
    {
        Paginate<Product> order = await _productRepository.GetListAsync(
    index: request.PageRequest.PageIndex,
    size: request.PageRequest.PageSize,
    cancellationToken: cancellationToken
    );

        GetListResponse<GetListProductListItemDto> response = _mapper.Map<GetListResponse<GetListProductListItemDto>>(order);
        return response;
    }
}


