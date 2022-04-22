using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;
using PizzaMarket.Domain.Repository;

namespace PizzaMarket.Logic.UseCases.PayForTheOrder
{
    public class PayForTheOrderHandler : INotificationHandler<PayForTheOrderRequest>
    {
        private readonly Func<IUnitOfWork> _unitOfWork;
        private readonly ILogger _logger;

        public PayForTheOrderHandler(Func<IUnitOfWork> unitOfWork, ILogger<PayForTheOrderRequest> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task Handle(PayForTheOrderRequest notification, CancellationToken cancellationToken)
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

            customer.CurrentOrder.PayForTheOrder();

            await db.SaveAsync();
        }
    }
}
