using System;
using MediatR;

namespace PizzaMarket.Logic.UseCases.AddProductToOrder
{
    public class AddProdcutToOrderRequest : INotification
    {
        public int CustomerId { get; }
        public int ProductId { get; }

        public AddProdcutToOrderRequest(int customerId, int productId)
        {
            CustomerId = customerId;
            ProductId = productId;
        }
    }
}
