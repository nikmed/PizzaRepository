using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;
using PizzaMarket.Domain.Repository;

namespace PizzaMarket.Logic.UseCases.CreateProduct
{
    public class CreateProductHandler : INotificationHandler<CreateProductRequest>
    {
        private readonly Func<IUnitOfWork> _unitOfWork;
        private readonly ILogger _logger;

        public CreateProductHandler(Func<IUnitOfWork> unitOfWork, ILogger<CreateProductHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task Handle(CreateProductRequest notification, CancellationToken cancellationToken)
        {
            using var db = _unitOfWork();

            var newProduct = new Domain.Model.Product(notification.Name,
                notification.Coast);


            db.Products.Add(newProduct);
            await db.SaveAsync();
        }
    }
}
