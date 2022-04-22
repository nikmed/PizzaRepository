using System;
using MediatR;
using PizzaMarket.Logic.Dto;

namespace PizzaMarket.Logic.UseCases.GetOrderHistory
{
    public class GetOrderHistoryRequest : IRequest<OrderHistoryDto>
    {

        public int CustomerId { get; }

        public GetOrderHistoryRequest(int customerId)
        {
            CustomerId = customerId;
        }
    }
}
