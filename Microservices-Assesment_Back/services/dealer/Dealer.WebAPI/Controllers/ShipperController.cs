using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;
using Dealer.Application.Features.Shippers.Commands.Create;
using Dealer.Application.Features.Shippers.Queries.GetByList;
using Dealer.Application.Features.Shippers.Queries.GetById;

namespace Dealer.WebAPI.Controllers;


[Route("api/[controller]")]
[ApiController]
public class ShipperController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateShipperCommand createShipperCommand)
    {
        CreatedShipperResponse res = await Mediator.Send(createShipperCommand);
        return Ok(res);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {

        GetListShipperQuery getListShipperQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListShipperListItemDto> response = await Mediator.Send(getListShipperQuery);
        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        GetByIdShipperQuery getByIdShipperQuery = new() { Id = id };
        GetByIdShipperResponse response = await Mediator.Send(getByIdShipperQuery);
        return Ok(response);

    }
}
    
