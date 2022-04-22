using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;
using PizzaMarket.Domain.Repository;

namespace PizzaMarket.Logic.UseCases.DilverTheOrder
{
    public class DeliverTheOrderHandler : INotificationHandler<DeliverTheOrderRequest>
    {
        private readonly Func<IUnitOfWork> _unitOfWork;
        private readonly ILogger _logger;

        public DeliverTheOrderHandler(Func<IUnitOfWork> unitOfWork, ILogger<DeliverTheOrderHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task Handle(DeliverTheOrderRequest notification, CancellationToken cancellationToken)
        {
            using var db = _unitOfWork();

            var customer = db.Customers.Get(notification.CustomerId);

            if (customer == null)
            {
                throw new Exception("Customer not found");
            }

            if (customer.CurrentOrder == null)
            {
                throw new Exception("Customer haven't order");
            }

            customer.CurrentOrder.DeliverTheOrder();

            await db.SaveAsync();
        }
    }
}
