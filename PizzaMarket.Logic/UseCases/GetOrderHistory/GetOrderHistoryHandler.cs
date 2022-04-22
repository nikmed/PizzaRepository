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
    public class GetOrderHistoryHandler : IRequestHandler<GetOrderHistoryRequest, OrderHistoryDto>
    {

        private readonly Func<IUnitOfWork> _unitOfWork;
        private readonly ILogger _logger;

        public GetOrderHistoryHandler(Func<IUnitOfWork> unitOfWork, ILogger<GetOrderHistoryRequest> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task<OrderHistoryDto> Handle(GetOrderHistoryRequest request, CancellationToken cancellationToken)
        {
            using var db = _unitOfWork();

            var customer = db.Customers.Get(request.CustomerId);

            return MapToOrderHistoryDto(customer.GetOrderHistory());
        }

        private OrderHistoryDto MapToOrderHistoryDto(IReadOnlyList<Domain.Model.Order> orderHistory)
        {
            return new OrderHistoryDto()
            {
                OrderHistory = orderHistory.Select(a => new OrderDto
                {
                    Id = a.Id,
                    Status = a.Status,
                    Products = MapToProductDto(a.ProductList)
                }).ToArray()
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
