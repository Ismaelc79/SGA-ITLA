using System;
using System.Windows.Forms; 
using Microsoft.Extensions.DependencyInjection;
using SGA.Application.Interfaces;
using SGA.Application.Services;
namespace SGA.Desktop
{
    static class Program
    {
        // Esta variable será la "caja" donde guardaremos sus servicios
        public static IServiceProvider ServiceProvider { get; private set; }

        [STAThread]
        static void Main()
        {
            var services = new ServiceCollection();

            // AQUÍ INTEGRAMOS SUS MÓDULOS (La parte que le faltaba)
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<INotificationService, NotificationService>();

            ServiceProvider = services.BuildServiceProvider();

            System.Windows.Forms.Application.EnableVisualStyles();
            System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);
            System.Windows.Forms.Application.Run(new Form1());
        }
    }
}