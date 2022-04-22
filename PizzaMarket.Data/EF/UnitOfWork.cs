using System;
using System.Threading.Tasks;
using PizzaMarket.Domain.Repository;
using PizzaMarket.Infratructure.EF.Repository;

namespace PizzaMarket.Infratructure.EF
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationContext _db;

        public UnitOfWork(ApplicationContext db)
        {
            _db = db;
        }

        private CustomerRepository customerRepository;
        private ProductRepository productRepository;
        private ProductListRepository productListRepository;
        private OrderRepository orderRepository;


        public ICustomerRepository Customers
        {
            get
            {
                if (customerRepository == null)
                    customerRepository = new CustomerRepository(_db);
                return (ICustomerRepository)customerRepository;
            }
        }

        public IProductRepository Products
        {
            get
            {
                if (productRepository == null)
                    productRepository = new ProductRepository(_db);
                return (IProductRepository)productRepository;
            }
        }

        public IProductListRepository ProductList
        {
            get
            {
                if (productListRepository == null)
                    productListRepository = new ProductListRepository(_db);
                return (IProductListRepository)productListRepository;
            }
        }

        public IOrderRepository Orders
        {
            get
            {
                if (orderRepository == null)
                    orderRepository = new OrderRepository(_db);
                return (IOrderRepository)orderRepository;
            }
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public Task SaveAsync()
        {
            _db.SaveChangesAsync();
            return Task.CompletedTask;
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _db.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
