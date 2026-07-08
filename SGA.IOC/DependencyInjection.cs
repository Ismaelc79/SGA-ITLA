using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SGA.Application.Interfaces.Configuration;
using SGA.Application.Services.Configuration;
using SGA.Persistence.Interfaces.Trips;
namespace SGA.IOC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDependencyInjection(
            this IServiceCollection services)
           
        {
            services.AddScoped<IBusService, BusService>();
            services.AddScoped<IRutaService, RutaService>();
            return services;
        }
    }
}
