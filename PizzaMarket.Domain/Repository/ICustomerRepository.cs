using System;
using PizzaMarket.Domain.Model;

namespace PizzaMarket.Domain.Repository
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        Customer Get(int id);
    }
}
