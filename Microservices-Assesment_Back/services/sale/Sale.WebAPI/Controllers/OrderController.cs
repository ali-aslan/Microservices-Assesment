using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sale.Application.Features.Orders.Commands.Create;
using Sale.Application.Features.Orders.Commands.Delete;
using Sale.Application.Features.Orders.Queries.GetByCustomerId;
using Sale.Application.Features.Orders.Queries.GetBySellerId;
using Sale.Application.Features.Orders.Queries.GetList;

namespace Sale.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController:BaseController
    {
        [HttpPost]
        [Authorize(Roles = "Admin,Sale")]
        public async Task<IActionResult> Add([FromBody] CreateOrderCommand createOrderCommand)
        {
            CreatedOrderResponse res = await Mediator.Send(createOrderCommand);
            return Ok(res);
        }

        [HttpGet]
        [Authorize(Roles = "Admin,Sale")]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {

           GetListOrderQuery getListOrderQuery = new() { PageRequest = pageRequest };
            GetListResponse<GetListOrderListItemDto> response = await Mediator.Send(getListOrderQuery);
            return Ok(response);
        }

        [HttpGet("Seller/{SellerId}")]
        [Authorize(Roles = "Admin,Sale")]
        public async Task<IActionResult> GetBySellerId([FromRoute] Guid SellerId)
        {
            GetOrderBySellerIdQuery getOrderBySellerIdQuery  = new() { SellerId = SellerId };
            GetOrderBySellerIdResponse response = await Mediator.Send(getOrderBySellerIdQuery);
            return Ok(response);
 
        }

        [HttpGet("Customer/{CustomerId}")]
        [Authorize(Roles = "Admin,Sale")]
        public async Task<IActionResult> GetByCustomerId([FromRoute] Guid CustomerId)
        {
            GetOrderByCustomerIdQuery getOrderByCustomerIdQuery = new() { CustomerId = CustomerId };
            GetOrderByCustomerIdResponse response = await Mediator.Send(getOrderByCustomerIdQuery);
            return Ok(response);

        }


        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin,Sale")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            DeleteOrderCommand deleteOrderCommand = new() { Id = id };
            DeletedOrderResponse response = await Mediator.Send(deleteOrderCommand);
            return Ok(response);
        }
    }
}
