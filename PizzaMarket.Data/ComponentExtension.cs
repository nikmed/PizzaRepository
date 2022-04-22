using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using System;
using PizzaMarket.Infratructure.EF;
using Microsoft.EntityFrameworkCore;
using PizzaMarket.Domain.Repository;

namespace PizzaMarket.Infratructure
{
    public static class ComponentExtension
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var dbConnectionString = configuration.GetConnectionString("DbContext");

            return services
                .AddTransient<ApplicationContext>(a => new ApplicationContext(dbConnectionString))
                .AddSingleton<Func<IUnitOfWork>>(a => () => new UnitOfWork(a.GetRequiredService<ApplicationContext>()))
                .MigrateOrCreateDbIfNeeded();
        }

        public static IServiceCollection MigrateOrCreateDbIfNeeded(this IServiceCollection services)
        {
            var db = services.BuildServiceProvider().GetService<ApplicationContext>();
            if (db.Database.EnsureCreated())
            {
                db.Database.Migrate();
            }
            return services;

        }
    }
}
