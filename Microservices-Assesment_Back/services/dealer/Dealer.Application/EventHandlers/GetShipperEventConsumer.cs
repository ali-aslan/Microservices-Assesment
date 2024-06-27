using AutoMapper;
using Contracts.Request;
using Contracts.Responses;
using Dealer.Application.Services.Repositories;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dealer.Application.EventHandlers;

public class GetShipperEventConsumer : IConsumer<ShipperRequest>
{
    private readonly IShipperRepository _shipperRepository;
    private readonly IMapper _mapper;

    public GetShipperEventConsumer(IShipperRepository shipperRepository, IMapper mapper)
    {
        _shipperRepository = shipperRepository;
        _mapper = mapper;
    }

    public async Task Consume(ConsumeContext<ShipperRequest> context)
    {
        var shipper = await _shipperRepository.GetAsync(s => s.Id == context.Message.Id);
        var mappedShipper = _mapper.Map<ShipperResponse>(shipper);
        await context.RespondAsync<ShipperResponse>(mappedShipper);


    }


}
