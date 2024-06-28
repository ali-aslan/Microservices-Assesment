using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;
using Dealer.Application.Features.Shippers.Commands.Create;
using Dealer.Application.Features.Shippers.Queries.GetByList;
using Dealer.Application.Features.Shippers.Queries.GetById;
using Microsoft.AspNetCore.Authorization;

namespace Dealer.WebAPI.Controllers;


[Route("api/[controller]")]
[ApiController]
public class ShipperController : BaseController
{
    [HttpPost]
    [Authorize(Roles = "Admin,Dealer")]
    public async Task<IActionResult> Add([FromBody] CreateShipperCommand createShipperCommand)
    {
        CreatedShipperResponse res = await Mediator.Send(createShipperCommand);
        return Ok(res);
    }

    [HttpGet]
    [Authorize(Roles = "Admin,Dealer")]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {

        GetListShipperQuery getListShipperQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListShipperListItemDto> response = await Mediator.Send(getListShipperQuery);
        return Ok(response);
    }

    [HttpGet("{id}")]
    [Authorize(Roles = "Admin,Dealer")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        GetByIdShipperQuery getByIdShipperQuery = new() { Id = id };
        GetByIdShipperResponse response = await Mediator.Send(getByIdShipperQuery);
        return Ok(response);

    }
}
    
