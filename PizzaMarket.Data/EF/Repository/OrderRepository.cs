using System;
using System.Linq;
using System.Linq.Expressions;
using PizzaMarket.Domain.Model;
using PizzaMarket.Domain.Repository;

namespace PizzaMarket.Infratructure.EF.Repository
{
    public class OrderRepository : IOrderRepository
    { 
        private readonly ApplicationContext _db;

        public OrderRepository(ApplicationContext db)
        {
            _db = db;
        }

        public void Add(Order entity)
        {
            _db.Orders.Add(entity);
        }

        public void Delete(Order entity)
        {
            _db.Orders.Remove(entity);
        }

        public Order Get(int id)
        {
            return _db.Orders.FirstOrDefault(a => a.Id == id);
        }

        public void Update(Order entity)
        {
            _db.Orders.Update(entity);
        }

        public IQueryable<Order> Where(Expression<Func<Order, bool>> expression)
        {
            return _db.Orders.Where(expression);
        }
    }
}
