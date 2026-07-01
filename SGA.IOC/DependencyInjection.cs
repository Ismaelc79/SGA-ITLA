using Microsoft.Extensions.DependencyInjection;
namespace SGA.IOC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
           return services;
        }
    }
}
