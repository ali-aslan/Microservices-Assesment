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

namespace Dealer.Application.Features.Shippers.Queries.GetByList;

public class GetListShipperQuery : IRequest<GetListResponse<GetListShipperListItemDto>>
{
    public PageRequest PageRequest { get; set; }
}

public class GetListShipperQueryHandler : IRequestHandler<GetListShipperQuery, GetListResponse<GetListShipperListItemDto>>
{

    private readonly IShipperRepository _shipperRepository;
    private readonly IMapper _mapper;

    public GetListShipperQueryHandler(IShipperRepository shipperRepository, IMapper mapper)
    {
        _shipperRepository = shipperRepository;
        _mapper = mapper;
    }

    public async Task<GetListResponse<GetListShipperListItemDto>> Handle(GetListShipperQuery request, CancellationToken cancellationToken)
    {
        Paginate<Shipper> shipper = await _shipperRepository.GetListAsync(
       index: request.PageRequest.PageIndex,
       size: request.PageRequest.PageSize,
       cancellationToken: cancellationToken
       );

        GetListResponse<GetListShipperListItemDto> response = _mapper.Map<GetListResponse<GetListShipperListItemDto>>(shipper);
        return response;
    }
}
