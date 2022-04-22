using System;
using MediatR;

namespace PizzaMarket.Logic.UseCases.DilverTheOrder
{
    public class DeliverTheOrderRequest : INotification
    {
        public int CustomerId { get; set; }

        public DeliverTheOrderRequest(int customerId)
        {
            CustomerId = customerId;
        }
    }
}
