using System;
using MediatR;

namespace PizzaMarket.Logic.UseCases.PayForTheOrder
{
    public class PayForTheOrderRequest : INotification
    {
        public int CustomerId { get; }

        public PayForTheOrderRequest(int customerId)
        {
            CustomerId = customerId;
        }
    }
}
