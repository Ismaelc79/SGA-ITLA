using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SGA.Persistence.Context;

namespace SGA.Persistence.ServiceExtensions
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(
            this IServiceCollection services,
            IConfiguration configuration)

        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<SGADB>(options =>
                    options.UseSqlServer(connectionString));               
                
                return services;
        }
       

    }
        
    }

