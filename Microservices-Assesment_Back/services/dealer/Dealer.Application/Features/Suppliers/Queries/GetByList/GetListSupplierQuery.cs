using AutoMapper;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using Dealer.Application.Services.Repositories;
using Dealer.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dealer.Application.Features.Suppliers.Queries.GetByList;

public class GetListSupplierQuery : IRequest<GetListResponse<GetListSupplierListItemDto>>
{
    public PageRequest PageRequest { get; set; }
}

public class GetListSupplierQueryHandler : IRequestHandler<GetListSupplierQuery, GetListResponse<GetListSupplierListItemDto>>
{

    private readonly ISupplierRepository _supplierRepository;
    private readonly IMapper _mapper;

    public GetListSupplierQueryHandler(ISupplierRepository supplierRepository, IMapper mapper)
    {
        _supplierRepository = supplierRepository;
        _mapper = mapper;
    }

    public async Task<GetListResponse<GetListSupplierListItemDto>> Handle(GetListSupplierQuery request, CancellationToken cancellationToken)
    {
        Paginate<Supplier> supplier = await _supplierRepository.GetListAsync(
       index: request.PageRequest.PageIndex,
       size: request.PageRequest.PageSize,
       cancellationToken: cancellationToken
       );

        GetListResponse<GetListSupplierListItemDto> response = _mapper.Map<GetListResponse<GetListSupplierListItemDto>>(supplier);
        return response;
    }
}
