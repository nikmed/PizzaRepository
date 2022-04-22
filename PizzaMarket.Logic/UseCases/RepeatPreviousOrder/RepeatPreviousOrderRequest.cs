using System;
using MediatR;

namespace PizzaMarket.Logic.UseCases.RepeatPreviousOrder
{
    public class RepeatPreviousOrderRequest : INotification
    {
        public int CustomerId { get; set; }
        public int OrderId { get; }

        public RepeatPreviousOrderRequest(int customerId, int orderId)
        {
            CustomerId = customerId;
            OrderId = orderId;
        }
    }
}
