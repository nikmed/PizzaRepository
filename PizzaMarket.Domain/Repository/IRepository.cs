using System;
using System.Linq;
using System.Linq.Expressions;

namespace PizzaMarket.Domain.Repository
{
    public interface IRepository<T> where T : class
    {
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);
        IQueryable<T> Where(Expression<Func<T, bool>> expression);
    }
}
