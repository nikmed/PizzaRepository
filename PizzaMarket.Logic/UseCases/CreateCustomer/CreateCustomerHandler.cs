using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;
using PizzaMarket.Domain.Repository;

namespace PizzaMarket.Logic.UseCases.CreateCustomer
{
    public class CreateCustomerHandler : INotificationHandler<CreateCustomerRequest>
    {
        private readonly Func<IUnitOfWork> _unitOfWork;
        private readonly ILogger _logger;

        public CreateCustomerHandler(Func<IUnitOfWork> unitOfWork, ILogger<CreateCustomerHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task Handle(CreateCustomerRequest notification, CancellationToken cancellationToken)
        {
            using var db = _unitOfWork();
            var newCustomer = new Domain.Model.Customer(notification.FirstName,
                notification.LastName,
                notification.Address,
                notification.Phone);


            db.Customers.Add(newCustomer);
            await db.SaveAsync();
        
        }
    }
}
