using Microsoft.EntityFrameworkCore;
using SGA.Domain.Entities.Authorization;
using SGA.Domain.Entities.Configuration;
using SGA.Domain.Entities.Users;

namespace SGA.Persistence.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
            : base(options)
        {

        }

        public DbSet<Autorizacion> Autorizaciones { get; set; }
        public DbSet<Pago> Pagos { get; set; }
        public DbSet<RegistroAcceso> RegistrosAccesos { get; set; }
        public DbSet<TarjetaRecargable> TarjetasRecargables { get; set; }
        public DbSet<Ticket> Tickets { get; set; }

        public DbSet<Bus> Buses { get; set; }
        public DbSet<Horario> Horarios { get; set; }
        public DbSet<Parada> Paradas { get; set; }
        public DbSet<Ruta> Rutas { get; set; }

        public DbSet<Conductor> Conductores { get; set; }
        public DbSet<Empleado> Empleados { get; set; }
        public DbSet<Estudiante> Estudiantes { get; set; }
        public DbSet<Rol> Roles { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Autorizacion>().ToTable("Autorizacion");
            modelBuilder.Entity<Autorizacion>().ToTable("Pago");
            modelBuilder.Entity<Autorizacion>().ToTable("RegistroAcceso");
            modelBuilder.Entity<Autorizacion>().ToTable("TarjetaRecargable");
            modelBuilder.Entity<Autorizacion>().ToTable("Ticket");

            modelBuilder.Entity<Autorizacion>().ToTable("Bus");
            modelBuilder.Entity<Autorizacion>().ToTable("Horario");
            modelBuilder.Entity<Autorizacion>().ToTable("Parada");
            modelBuilder.Entity<Autorizacion>().ToTable("Ruta");
            modelBuilder.Entity<Autorizacion>().ToTable("Incidencia");
            modelBuilder.Entity<Autorizacion>().ToTable("Viaje");

            modelBuilder.Entity<Autorizacion>().ToTable("Conductor");
            modelBuilder.Entity<Autorizacion>().ToTable("Empleadp");
            modelBuilder.Entity<Autorizacion>().ToTable("Estudiante");
            modelBuilder.Entity<Autorizacion>().ToTable("Rol");
            modelBuilder.Entity<Autorizacion>().ToTable("Usuario");
            modelBuilder.Entity<Autorizacion>().ToTable("Notificaciones");

            modelBuilder.Entity<Autorizacion>()
                .Property(x => x.FechaInicio)
                .HasDefaultValueSql("GETDATE()");

        }




    }
}
