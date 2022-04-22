using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using PizzaMarket.Logic.Dto;
using PizzaMarket.Logic.UseCases.AddProductToOrder;
using PizzaMarket.Logic.UseCases.CreateCustomer;
using PizzaMarket.Logic.UseCases.DeleteProduct;
using PizzaMarket.Logic.UseCases.DilverTheOrder;
using PizzaMarket.Logic.UseCases.GetOrderHistory;
using PizzaMarket.Logic.UseCases.GetProducts;
using PizzaMarket.Logic.UseCases.PayForTheOrder;
using PizzaMarket.Logic.UseCases.RepeatPreviousOrder;
using PizzaMarket.WebApi.Dto;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PizzaMarket.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class PizzaController : Controller
    {
        private readonly IMediator _mediator;

        public PizzaController(IMediator mediator)
        {
            _mediator = mediator;
        }
        
        [HttpGet("get-products")]
        public async Task<ProductDto[]> GetProducts()
        {
            return await _mediator.Send(new GetProdcutsRequest());
        }

        [HttpGet("get-order/{customerId}")]
        public async Task<OrderDto> GetOrder(int customerId)
        {
            return await _mediator.Send(new GetOrderRequest(customerId));
        }

        [HttpGet("get-order-history/{customerId}")]
        public async Task<OrderHistoryDto> GetOrderHistory(int customerId)
        {
            return await _mediator.Send(new GetOrderHistoryRequest(customerId));
        }

        [HttpPut("add-product/{customerId}/{productId}")]
        public async Task<ActionResult> AddProduct(int customerId, int productId)
        {
            await _mediator.Publish(new AddProdcutToOrderRequest(customerId, productId));
            return Ok();
        }

        [HttpPut("delete-product/{customerId}/{productId}")]
        public async Task<ActionResult> DeleteProduct(int customerId, int productId)
        {
            await _mediator.Publish(new DeleteProductFromOrderRequest(customerId, productId));
            return Ok();
        }

        [HttpPost("create-customer")]
        public async Task<ActionResult> CreateCutomer([FromBody]CreateCustomerDto dto)
        {
            await _mediator.Publish(new CreateCustomerRequest(dto.FirstName,
                dto.LastName,
                dto.Address,
                dto.Phone));

            return Ok();
        }

        [HttpPost("pay-for-the-order")]
        public async Task<ActionResult> PayForTheOrder([FromForm] int customerId)
        {
            await _mediator.Publish(new PayForTheOrderRequest(customerId));
            return Ok();
        }

        [HttpPost("deliver-for-the-order")]
        public async Task<ActionResult> DeliverTheOrder([FromForm] int customerId)
        {
            await _mediator.Publish(new DeliverTheOrderRequest(customerId));
            return Ok();
        }

        [HttpPost("repeat-previous-order")]
        public async Task<ActionResult> RepeatPreviousOrder([FromForm] int customerId, [FromForm] int orderId)
        {
            await _mediator.Publish(new RepeatPreviousOrderRequest(customerId, orderId));
            return Ok();
        }
    }
}
