using AutoMapper;
using Dealer.Application.Services.Repositories;
using Dealer.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dealer.Application.Features.Shippers.Commands.Create;

public class CreateShipperCommand:IRequest<CreatedShipperResponse>
{
    public string Name { get; set; }
    public string Phone { get; set; }
}

public class CreateShipperCommandHandler: IRequestHandler<CreateShipperCommand,CreatedShipperResponse>
{
    private readonly IShipperRepository _shipperRepository;
    private readonly IMapper _mapper;

    public CreateShipperCommandHandler(IShipperRepository shipperRepository, IMapper mapper)
    {
        _shipperRepository = shipperRepository;
        _mapper = mapper;
    }

    public async Task<CreatedShipperResponse>? Handle (CreateShipperCommand request, CancellationToken cancellationToken)
    {
        Shipper shipper = _mapper.Map<Shipper>(request);
        shipper.Id = new Guid();

        await _shipperRepository.AddAsync(shipper);

        CreatedShipperResponse createdShipperResponse= _mapper.Map<CreatedShipperResponse>(shipper);
        return createdShipperResponse;

    }

}
