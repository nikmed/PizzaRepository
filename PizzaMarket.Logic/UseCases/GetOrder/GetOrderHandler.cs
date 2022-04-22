using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;
using PizzaMarket.Domain.Model;
using PizzaMarket.Domain.Repository;
using PizzaMarket.Logic.Dto;

namespace PizzaMarket.Logic.UseCases.GetOrderHistory
{
    public class GetOrderHandler : IRequestHandler<GetOrderRequest, OrderDto>
    {

        private readonly Func<IUnitOfWork> _unitOfWork;
        private readonly ILogger _logger;

        public GetOrderHandler(Func<IUnitOfWork> unitOfWork, ILogger<GetOrderHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task<OrderDto> Handle(GetOrderRequest request, CancellationToken cancellationToken)
        {
            using var db = _unitOfWork();

            var customer = db.Customers.Get(request.CustomerId);

            return new OrderDto()
            {
                Id = customer.CurrentOrder.Id,
                Status = customer.CurrentOrder.Status,
                Products = MapToProductDto(customer.CurrentOrder.ProductList)
            };
        }

        private OrderProductDto[] MapToProductDto(IReadOnlyList<ProductList> products)
        {
            return products.Select(a => new OrderProductDto
            {
                Name = a.Product.Name,
                Coast = a.Product.Coast,
                Count = a.Count
            }).ToArray();
        }
    }
}
