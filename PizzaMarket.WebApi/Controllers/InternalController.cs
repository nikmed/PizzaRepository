using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using PizzaMarket.Logic.UseCases.CreateProduct;
using PizzaMarket.WebApi.Dto;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PizzaMarket.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class InternalController : Controller
    {
        private readonly IMediator _mediator;

        public InternalController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("create-product")]
        public async Task<IActionResult> CreateProduct(CreatePrdouctDto productDto)
        {
            await _mediator.Publish(new CreateProductRequest(productDto.Name, productDto.Coast));
            return Ok();
        }
    }
}
