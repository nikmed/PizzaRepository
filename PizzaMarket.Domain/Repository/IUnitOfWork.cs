using System;
using System.Threading.Tasks;

namespace PizzaMarket.Domain.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        void Save();
        Task SaveAsync();

        ICustomerRepository Customers { get; }
        IOrderRepository Orders { get; }
        IProductRepository Products { get; }
        IProductListRepository ProductList { get; }
    }
}
