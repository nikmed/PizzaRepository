using System.Collections.Generic;
using System.Linq;

namespace PizzaMarket.Domain.Model
{
    public class Customer
    {
        public int Id { get; private set; }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Address { get; private set; }
        public string Phone { get; private set; }

        public Order CurrentOrder => Orders
            .FirstOrDefault(a => a.Status == OrderStatus.Unpaid || a.Status == OrderStatus.Paid );
        public IReadOnlyList<Order> Orders => _orders;
        private readonly List<Order> _orders;
        

        private Customer()
        {
            //EF
        }

        public Customer(string firstName, string lastName, string address, string phone)
        {
            FirstName = firstName;
            LastName = lastName;
            Address = address;
            Phone = phone;
            _orders = new List<Order>();
        }

        public void CreateOrder()
        {
            if (CurrentOrder == null)
                _orders.Add(new Order());
        }

        public void ReapeatOrder(int orderId)
        {
            if (CurrentOrder?.Status == OrderStatus.Paid)
            {
                throw new System.Exception("Customer have paid order");
            }

            var orderHistory = Orders.Where(a => a.Status == OrderStatus.Delivered);

            var order = orderHistory.FirstOrDefault(a => a.Id == orderId);
            if (order == null)
            {
                throw new System.Exception("Order not found");
            }

            CreateOrder();
            CurrentOrder.ClearOrder();
            foreach (var item in order.ProductList)
            {
                for (int i = 0; i < item.Count; i++)
                {
                    CurrentOrder.AddProduct(item.Product);
                }
            }
        }

        public void PayTheOrder()
        {
            if (CurrentOrder == null)
                throw new System.Exception("Customer don't have any order now");

            CurrentOrder.PayForTheOrder();
        }

        public void DeliverTheOrder()
        {
            if (CurrentOrder == null)
                throw new System.Exception("Customer don't have any order now");

            CurrentOrder.DeliverTheOrder();
        }

        public IReadOnlyList<Order> GetOrderHistory()
        {
            return Orders.Where(a => a.Status == OrderStatus.Delivered).ToList();
        }
    }
}
