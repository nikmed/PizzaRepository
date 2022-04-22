using System;
using PizzaMarket.Domain.Model;

namespace PizzaMarket.Domain.Repository
{
    public interface IProductListRepository : IRepository<ProductList>
    {
        ProductList Get(int id);
    }
}
