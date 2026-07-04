using Microsoft.Extensions.DependencyInjection;
using SGA.Application.Interfaces;
using SGA.Application.Services;

namespace SGA.Desktop.Services
{
    public static class NotificationDependency
    {
        public static IServiceCollection AddNotificationDependency(this IServiceCollection services)
        {
            services.AddTransient<INotificationService, NotificationService>();
            
            return services;
        }
    }
}