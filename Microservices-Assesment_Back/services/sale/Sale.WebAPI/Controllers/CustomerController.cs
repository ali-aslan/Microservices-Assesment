using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sale.Application.Features.Customers.Commands.Create;
using Sale.Application.Features.Customers.Commands.Delete;
using Sale.Application.Features.Customers.Queries.GetById;
using Sale.Application.Features.Customers.Queries.GetList;

namespace Sale.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController:BaseController
    {
        [HttpPost]
        [Authorize(Roles = "Admin,Sale")]
        public async Task<IActionResult> Add([FromBody] CreateCustomerCommand createCustomerCommand)
        {
            CreatedCustomerResponse res = await Mediator.Send(createCustomerCommand);
            return Ok(res);
        }

        [HttpGet]
        [Authorize(Roles = "Admin,Sale")]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {

           GetListCustomerQuery getListCustomerQuery = new() { PageRequest = pageRequest };
            GetListResponse<GetListCustomerListItemDto> response = await Mediator.Send(getListCustomerQuery);
            return Ok(response);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Admin,Sale")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            GetByIdCustomerQuery getByIdCustomerQuery = new() { Id = id };
            GetByIdCustomerResponse response = await Mediator.Send(getByIdCustomerQuery);
            return Ok(response);
 
        }


        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin,Sale")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            DeleteCustomerCommand deleteCustomerCommand = new() { Id = id };
            DeletedCustomerResponse response = await Mediator.Send(deleteCustomerCommand);
            return Ok(response);
        }
    }
}
