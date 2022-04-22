using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;
using PizzaMarket.Domain.Repository;

namespace PizzaMarket.Logic.UseCases.DeleteProduct
{
    public class DeleteProductFromOrderHandler : INotificationHandler<DeleteProductFromOrderRequest>
    {
        private readonly Func<IUnitOfWork> _unitOfWork;
        private readonly ILogger _logger;

        public DeleteProductFromOrderHandler(Func<IUnitOfWork> unitOfWork, ILogger<DeleteProductFromOrderHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task Handle(DeleteProductFromOrderRequest notification, CancellationToken cancellationToken)
        {
            using var db = _unitOfWork();

            var customer = db.Customers.Get(notification.CustomerId);

            if (customer == null)
            {
                _logger.LogError("Cusotmer not found");
                throw new Exception("Cusotmer not found");
            }

            if (customer.CurrentOrder == null)
            {
                _logger.LogError("Order not created");
                throw new Exception("Order not created");
            }

            var product = db.Products.Get(notification.ProductId);

            if (product == null)
            {
                _logger.LogError("Product not found");
                throw new Exception("Product not found");
            }

            customer.CurrentOrder.DeleteProduct(product);

            await db.SaveAsync();
        }
    }
}
