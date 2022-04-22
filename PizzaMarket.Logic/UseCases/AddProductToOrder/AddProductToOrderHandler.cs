using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;
using PizzaMarket.Domain.Repository;

namespace PizzaMarket.Logic.UseCases.AddProductToOrder
{
    public class AddProductToOrderHandler : INotificationHandler<AddProdcutToOrderRequest>
    {
        private readonly Func<IUnitOfWork> _unitOfWork;
        private readonly ILogger _logger;

        public AddProductToOrderHandler(Func<IUnitOfWork> unitOfWork, ILogger<AddProductToOrderHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task Handle(AddProdcutToOrderRequest request, CancellationToken cancellationToken)
        {
            using var db = _unitOfWork();
            var customer = db.Customers.Get(request.CustomerId);

            if (customer == null)
            {
                _logger.LogError("Cusotmer not found");
                throw new Exception("Cusotmer not found");
            }

            if (customer.CurrentOrder == null)
            {
                customer.CreateOrder();
            }

            var product = db.Products.Get(request.ProductId);

            if (product == null)
            {
                _logger.LogError("Product not found");
                throw new Exception("Product not found");
            }

            customer.CurrentOrder.AddProduct(product);

            await db.SaveAsync();

        }
    }
}
