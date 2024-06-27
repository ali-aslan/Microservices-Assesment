using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;
using Sale.Application.Features.Products.Commands.Create;
using Sale.Application.Features.Products.Queries.GetList;

namespace Sale.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateProductCommand createProductCommand)
        {
            CreatedProductResponse res = await Mediator.Send(createProductCommand);
            return Ok(res);
        }

        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {

            GetListProductQuery getListProductQuery = new() { PageRequest = pageRequest };
            GetListResponse<GetListProductListItemDto> response = await Mediator.Send(getListProductQuery);
            return Ok(response);
        }

    }
}
