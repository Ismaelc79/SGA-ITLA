using System;
using System.Windows.Forms;
using Microsoft.Extensions.DependencyInjection;
using SGA.Application.Interfaces;
using SGA.Application.Interfaces.User;
using SGA.Application.Services;
using SGA.Application.Services.User;
using SGA.Desktop.Services;

namespace SGA.Desktop
{
    static class Program
    {
        public static IServiceProvider ServiceProvider { get; private set; }

        [STAThread]
        static void Main()
        {
            var services = new ServiceCollection();

        
            services.AddNotificationDependency();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<INotificationService, NotificationService>();

            ServiceProvider = services.BuildServiceProvider();

            
            System.Windows.Forms.Application.EnableVisualStyles();
            System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);
            System.Windows.Forms.Application.Run(new Form1());
        }
    }
}