using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SGA.Persistence.Context;
using SGA.Persistence.Interfaces;
using SGA.Persistence.Interfaces.Autorizations;
using SGA.Persistence.Interfaces.Trips;
using SGA.Persistence.Interfaces.Users;
using SGA.Persistence.Repositories.Autorizations;
using SGA.Persistence.Repositories.Trips;
using SGA.Persistence.Repositories.Users;

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
            
            services.AddScoped<IAutorizacionRepository, AutorizacionRepository>();
            services.AddScoped<IPagoRepository, PagoRepository>();
            services.AddScoped<IRegistroAccesoRepository, RegistroAccesoRepository>();
            services.AddScoped<ITarjetaRecargableRepository, TarjetaRecargableRepository>();
            services.AddScoped<ITicketRepository, TicketRepository>();

            services.AddScoped<IBusRepository, BusRepository>();
            services.AddScoped<IHorarioRepository, HorarioRepository>();
            services.AddScoped<IIncidenciaRepository, IncidenciaRepository>();
            services.AddScoped<INotificacionRepository, NotificacionRepository>();
            services.AddScoped<IParadaRepository, ParadaRepository>();
            services.AddScoped<IRutaRepository, RutaRepository>();
            services.AddScoped<IViajeRepository, ViajeRepository>();

            services.AddScoped<IConductorRepository, ConductorRepository>();
            services.AddScoped<IEmpleadoRepository, EmpleadoRepository>();
            services.AddScoped<IEstudianteRepository, EstudianteRepository>();
            services.AddScoped<IRolRepository, RolRepository>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            return services;
        }
       

    }
        
    }

