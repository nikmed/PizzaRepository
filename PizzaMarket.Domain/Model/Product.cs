using System;
using System.Collections.Generic;

namespace PizzaMarket.Domain.Model
{
    public class Product
    {
        public int Id { get; private set; }

        public string Name { get; private set; }
        public int Coast { get; private set; }

        private readonly List<ProductList> _productLists = new List<ProductList>();
        public IReadOnlyList<ProductList> ProductList => _productLists;

        private Product()
        {

        }

        public Product(string name, int coast)
        {
            Name = name;
            Coast = coast;
        }
    }
}
