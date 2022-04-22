using System;
using MediatR;

namespace PizzaMarket.Logic.UseCases.CreateProduct
{
    public class CreateProductRequest : INotification
    {
        public string Name { get; }
        public int Coast { get; }

        public CreateProductRequest(string name, int coast)
        {
            Name = name;
            Coast = coast;
        }
    }
}
