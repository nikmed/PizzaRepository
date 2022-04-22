using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;
using PizzaMarket.Domain.Repository;

namespace PizzaMarket.Logic.UseCases.RepeatPreviousOrder
{
    public class RepeatPreviousOrderHandler : INotificationHandler<RepeatPreviousOrderRequest>
    {
        private readonly Func<IUnitOfWork> _unitOfWork;
        private readonly ILogger _logger;

        public RepeatPreviousOrderHandler(Func<IUnitOfWork> unitOfWork, ILogger<RepeatPreviousOrderRequest> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task Handle(RepeatPreviousOrderRequest notification, CancellationToken cancellationToken)
        {
            using var db = _unitOfWork();
            var customer = db.Customers.Get(notification.CustomerId);

            if (customer == null)
            {
                throw new Exception("Customer not found");
            }

            customer.ReapeatOrder(notification.OrderId);

            await db.SaveAsync();
        }
    }
}
