using System;
using MediatR;
using PizzaMarket.Logic.Dto;

namespace PizzaMarket.Logic.UseCases.GetProducts
{
    public class GetProdcutsRequest : IRequest<ProductDto[]>
    {
    }
}
