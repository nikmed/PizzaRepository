using System;
using System.Linq;
using System.Linq.Expressions;
using PizzaMarket.Domain.Model;
using PizzaMarket.Domain.Repository;

namespace PizzaMarket.Infratructure.EF.Repository
{
    public class ProductListRepository : IProductListRepository
    {
        private readonly ApplicationContext _db;

        public ProductListRepository(ApplicationContext db)
        {
            _db = db;
        }

        public void Add(ProductList entity)
        {
            _db.ProductList.Add(entity);
        }

        public void Delete(ProductList entity)
        {
            _db.ProductList.Remove(entity);
        }

        public ProductList Get(int id)
        {
            return _db.ProductList.FirstOrDefault(a => a.Id == id);
        }

        public void Update(ProductList entity)
        {
            _db.ProductList.Update(entity);
        }

        public IQueryable<ProductList> Where(Expression<Func<ProductList, bool>> expression)
        {
            return _db.ProductList.Where(expression);
        }
    }
}
