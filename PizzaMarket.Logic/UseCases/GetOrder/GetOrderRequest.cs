using System;
using MediatR;
using PizzaMarket.Logic.Dto;

namespace PizzaMarket.Logic.UseCases.GetOrderHistory
{
    public class GetOrderRequest : IRequest<OrderDto>
    {

        public int CustomerId { get; }

        public GetOrderRequest(int customerId)
        {
            CustomerId = customerId;
        }
    }
}
