using System;
using PizzaMarket.Domain.Model;

namespace PizzaMarket.Domain.Repository
{
    public interface IProductRepository : IRepository<Product>
    {
        Product Get(int id);
    }
}
