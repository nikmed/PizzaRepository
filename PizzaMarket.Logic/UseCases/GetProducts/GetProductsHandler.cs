using System;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using MediatR;
using Microsoft.Extensions.Logging;
using PizzaMarket.Domain.Repository;
using PizzaMarket.Logic.Dto;

namespace PizzaMarket.Logic.UseCases.GetProducts
{
    public class GetProductsHandler : IRequestHandler<GetProdcutsRequest, ProductDto[]>
    {
        private readonly Func<IUnitOfWork> _unitOfWork;
        private readonly ILogger _logger;

        public GetProductsHandler(Func<IUnitOfWork> unitOfWork, ILogger<GetProductsHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task<ProductDto[]> Handle(GetProdcutsRequest request, CancellationToken cancellationToken)
        {
            using var db = _unitOfWork();

            var prodcuts = db.Products.Where(a => true);

            return prodcuts.Select(a => new ProductDto()
            {
                Id = a.Id,
                Coast = a.Coast,
                Name = a.Name
            }).ToArray();
        }
    }
}
