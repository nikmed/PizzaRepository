using System;
using System.Linq;
using System.Linq.Expressions;
using PizzaMarket.Domain.Model;
using PizzaMarket.Domain.Repository;

namespace PizzaMarket.Infratructure.EF.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationContext _db;

        public ProductRepository(ApplicationContext db)
        {
            _db = db;
        }

        public void Add(Product entity)
        {
            _db.Products.Add(entity);
        }

        public void Delete(Product entity)
        {
            _db.Products.Remove(entity);
        }

        public Product Get(int id)
        {
            return _db.Products.FirstOrDefault(a => a.Id == id);
        }

        public void Update(Product entity)
        {
            _db.Products.Update(entity);
        }

        public IQueryable<Product> Where(Expression<Func<Product, bool>> expression)
        {
            return _db.Products.Where(expression);
        }
    }
}
