using AutoMapper;
using Dealer.Application.Services.Repositories;
using Dealer.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dealer.Application.Features.Shippers.Queries.GetById;

public class GetByIdShipperQuery : IRequest<GetByIdShipperResponse>
{
    public Guid Id { get; set; }
}

public class GetByIdShipperQueryHandler : IRequestHandler<GetByIdShipperQuery, GetByIdShipperResponse>
{
    private readonly IMapper _mapper;
    private readonly IShipperRepository _shipperRepository;

    public GetByIdShipperQueryHandler(IMapper mapper, IShipperRepository shipperRepository)
    {
        _mapper = mapper;
        _shipperRepository = shipperRepository;
    }

    public async Task<GetByIdShipperResponse> Handle(GetByIdShipperQuery request, CancellationToken cancellationToken)
    {
        Shipper? shipper = await _shipperRepository.GetAsync(predicate: b => b.Id == request.Id, cancellationToken: cancellationToken);

        GetByIdShipperResponse response = _mapper.Map<GetByIdShipperResponse>(shipper);
        return response;
    }
}
