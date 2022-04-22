using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;


namespace PizzaMarket.WebApi
{
    public static class ComponentExtension
    {
        public static IWebHostBuilder AddPublicApi(this IWebHostBuilder builder)
        {
            builder
                .UseKestrel((context, opts) =>
                {
                    opts.ListenAnyIP(5001);
                })
                .ConfigureServices((context, services) =>
                {
                    services.AddControllers();
                    services.AddSwaggerGen(c =>
                    {
                        c.SwaggerDoc("v1", new OpenApiInfo { Title = "PizzaMarket", Version = "v1" });
                    });
                })
                .Configure((context, app) => {
                    app.UseDeveloperExceptionPage();
                    app.UseSwagger();
                    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "PizzaMarket"));

                    app.UseHttpsRedirection();

                    app.UseRouting();

                    app.UseAuthorization();

                    app.UseEndpoints(endpoints =>
                    {
                        endpoints.MapControllers();
                    });
                });

            return builder;

            
        }
    }
}
