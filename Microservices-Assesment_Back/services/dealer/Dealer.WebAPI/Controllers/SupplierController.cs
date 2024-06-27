using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;
using Dealer.Application.Features.Suppliers.Commands.Create;
using Dealer.Application.Features.Shippers.Queries.GetByList;
using Dealer.Application.Features.Shippers.Queries.GetById;
using Dealer.Application.Features.Suppliers.Queries.GetByList;
using Dealer.Application.Features.Suppliers.Queries.GetById;

namespace Dealer.WebAPI.Controllers;


[Route("api/[controller]")]
[ApiController]
public class SupplierController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateSupplierCommand createsupplierCommand)
    {
        CreatedSupplierResponse res = await Mediator.Send(createsupplierCommand);
        return Ok(res);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {

        GetListSupplierQuery getListSupplierQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListSupplierListItemDto> response = await Mediator.Send(getListSupplierQuery);
        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        GetByIdSupplierQuery getByIdSupplierQuery = new() { Id = id };
        GetByIdSupplierResponse response = await Mediator.Send(getByIdSupplierQuery);
        return Ok(response);

    }
}
    
