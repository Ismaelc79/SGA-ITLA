using Microsoft.Extensions.DependencyInjection;
using SGA.Application.Interfaces.Notification;
using SGA.Application.Services.Notification;

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