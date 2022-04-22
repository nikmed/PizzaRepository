using System;
using MediatR;

namespace PizzaMarket.Logic.UseCases.DeleteProduct
{
    public class DeleteProductFromOrderRequest : INotification
    {
        public int CustomerId { get; set; }
        public int ProductId { get; set; }

        public DeleteProductFromOrderRequest(int customerId, int productId)
        {
            CustomerId = customerId;
            ProductId = productId;
        }
    }
}
