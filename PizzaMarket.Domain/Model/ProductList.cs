using System;
namespace PizzaMarket.Domain.Model
{
    public class ProductList
    {
        public int Id { get; private set; }

        public Product Product { get; private set; }
        public Order Order { get; private set; }

        public int Count { get; private set; }

        private ProductList()
        {
            Count = 1;
        }

        public ProductList(Product product, Order order)
        {
            Product = product;
            Order = order;
            Count = 1;
        }

        public void Add()
        {
            Count += 1;
        }

        public void Decrease()
        {
            if (Count > 1)
            {
                Count -= 1;
            }
            else
            {
                throw new Exception("Count of products cannot't be lower then 1");
            }
        }
    }
}
