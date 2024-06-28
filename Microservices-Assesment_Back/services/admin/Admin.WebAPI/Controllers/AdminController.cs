using Admin.Application.Features.EventBus;
using Core.Application.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Admin.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AdminController:BaseController
{

    [HttpGet]
    [Authorize(Roles ="Admin")]
    public async Task<IActionResult> FetchOrder()
    {

        GetOrderQuery getListOrderQuery = new();
       GetOrderResponse  response = await Mediator.Send(getListOrderQuery);
        return Ok(response);
    }

}
