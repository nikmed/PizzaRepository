using System;
using PizzaMarket.Domain.Model;

namespace PizzaMarket.Domain.Repository
{
    public interface IOrderRepository : IRepository<Order>
    {
        Order Get(int id);
    }
}
