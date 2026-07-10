using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SGA.Application.Interfaces.Trip;
using SGA.Application.Interfaces.Trips;
using SGA.Application.Services.Configuration;
using SGA.Application.Services.Trips;
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
            services.AddScoped<IParadaService, ParadaService>();
            services.AddScoped<IHorarioService, HorarioService>();
            return services;

        }
    }
}
