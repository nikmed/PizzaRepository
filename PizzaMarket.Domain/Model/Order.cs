using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace PizzaMarket.Domain.Model
{
    public class Order
    {
        public int Id { get; private set; }
        public OrderStatus Status { get; private set; }

        public int Sum => _productLists.Where(a => a.Order == this).Sum(a => a.Count * a.Product.Coast);

        public Customer Customer { get; private set; }

        private readonly List<ProductList> _productLists = new List<ProductList>();
        public IReadOnlyList<ProductList> ProductList => _productLists;


        public Order()
        {
            Status = OrderStatus.Unpaid;
        }

        public void PayForTheOrder()
        {
            if (Status != OrderStatus.Unpaid)
                throw new Exception("Unavailable at current state");
            Status = OrderStatus.Paid;
        }

        public void DeliverTheOrder()
        {
            if (Status != OrderStatus.Paid)
                throw new Exception("Unavailable at current state");
            Status = OrderStatus.Delivered;
        }

        public void AddProduct(Product product)
        {
            var productInList = _productLists.FirstOrDefault(a => a.Order == this && a.Product == product);
            if (productInList != null)
            {
                productInList.Add();
            }
            else
            {
                _productLists.Add(new ProductList(product, this));
            }
           
        }

        public void DeleteProduct(Product product)
        {
            var productInList = _productLists.FirstOrDefault(a => a.Order == this && a.Product == product);
            if (productInList != null)
            {
                if (productInList.Count > 1)
                {
                    productInList.Decrease();
                }
                else
                {
                    _productLists.Remove(productInList);
                }
            }
        }

        public void ClearOrder()
        {
           _productLists.RemoveAll(a => a.Order == this);
        }
    }
}
