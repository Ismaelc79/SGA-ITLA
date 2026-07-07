using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SGA.Application.Interfaces.Configuration;
using SGA.Application.Services.Configuration;
namespace SGA.IOC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(
            this IServiceCollection services)
           
        {
            services.AddScoped<IBusService, BusService>();
            return services;
        }
    }
}
