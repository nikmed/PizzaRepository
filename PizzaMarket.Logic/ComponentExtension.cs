using System;
using System.Reflection;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace PizzaMarket.Logic
{
    public static class ComponentExtension
    {
        public static IServiceCollection AddLogic(this IServiceCollection services, IConfiguration configuration)
        {
            return services
                .AddMediatR(Assembly.GetExecutingAssembly());
        }
    }
}
