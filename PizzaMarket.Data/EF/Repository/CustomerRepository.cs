using System;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using PizzaMarket.Domain.Model;
using PizzaMarket.Domain.Repository;

namespace PizzaMarket.Infratructure.EF.Repository
{
    public class CustomerRepository : ICustomerRepository
    {

        private readonly ApplicationContext _db;

        public CustomerRepository(ApplicationContext db)
        {
            _db = db;
        }

        public void Add(Customer entity)
        {
            _db.Customers.Add(entity);
        }

        public void Delete(Customer entity)
        {
            _db.Customers.Remove(entity);
        }

        public Customer Get(int id)
        {
            return _db.Customers.FirstOrDefault(a => a.Id == id);
        }

        public void Update(Customer entity)
        {
            _db.Customers.Update(entity);
        }

        public IQueryable<Customer> Where(Expression<Func<Customer, bool>> expression)
        {
            return _db.Customers.Where(expression);
        }
    }
}
