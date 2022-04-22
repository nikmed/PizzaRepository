using System;
using System.Linq;
using System.Text.Json.Serialization;
using PizzaMarket.Domain;

namespace PizzaMarket.Logic.Dto
{
    public class OrderDto
    {
        public int Id { get; set; }
        [JsonIgnore]
        public OrderStatus Status { get; set; }
        public string OrderStatus => Status.ToString(); 
        public OrderProductDto[] Products { get; set; }
        public int OverallSum => Products.Sum(a => a.Coast * a.Count);
    }
}
