using System;
using System.IO;
using System.Reflection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using PizzaMarket.Infratructure;
using PizzaMarket.Logic;
using PizzaMarket.WebApi;

namespace PizzaMarket.Application
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            .ConfigureAppConfiguration((ctx, configurationBuilder) =>
            {
                configurationBuilder
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .AddEnvironmentVariables();
            })
            .ConfigureLogging((logger) =>
            {
                logger.AddConsole();
            })
            .ConfigureServices((builder, service) =>
            {
                service.AddInfrastructure(builder.Configuration);
                service.AddLogic(builder.Configuration);
            })
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.AddPublicApi();
            });
    }
}
