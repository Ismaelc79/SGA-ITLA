using Microsoft.EntityFrameworkCore;
using SGA.Domain.Base;
using SGA.Domain.Entities.Authorization;
using SGA.Domain.Entities.Configuration;
using SGA.Domain.Entities.Trip;
using SGA.Domain.Entities.Users;
using SGA.Domain.Notifications;

namespace SGA.Persistence.Context
{
    public class SGADB : DbContext
    {
        public SGADB(DbContextOptions<SGADB> options)
            : base(options)
        {

        }

        public DbSet<Autorizacion> Autorizaciones { get; set; }
        public DbSet<Pago> Pagos { get; set; }
        public DbSet<RegistroAcceso> RegistrosAccesos { get; set; }
        public DbSet<TarjetaRecargable> TarjetasRecargables { get; set; }
        public DbSet<Ticket> Tickets { get; set; }

        public DbSet<Domain.Entities.Trip.Bus> Buses { get; set; }
        public DbSet<Horario> Horarios { get; set; }
        public DbSet<Parada> Paradas { get; set; }
        public DbSet<Ruta> Rutas { get; set; }

        public DbSet<Conductor> Conductores { get; set; }
        public DbSet<Empleado> Empleados { get; set; }
        public DbSet<Estudiante> Estudiantes { get; set; }
        public DbSet<Rol> Roles { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Notificacion> Notificaciones { get; set; }

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
            modelBuilder.Entity<Notificacion>().ToTable("Notificaciones");

            modelBuilder.Entity<Autorizacion>()
                .Property(x => x.Estado)
                .HasConversion<string>();

            modelBuilder.Entity<Pago>(entity =>
            {
                entity.Property(x => x.MetodoPago)
                .HasConversion<string>();

                entity.Property(x => x.EstadoPago)
                .HasConversion<string>();

                entity.Property(x => x.MontoPago)
                .HasPrecision(18, 2);
            });

            modelBuilder.Entity<TarjetaRecargable>(entity =>
            {
                entity.Property(x => x.EstadoTarjeta)
                .HasConversion<string>();

                entity.Property(x => x.MontoTarjeta)
                .HasPrecision(18, 2);

            });

            modelBuilder.Entity<Ticket>()
                .Property(x => x.EstadoTicket)
                .HasConversion<string>();

            modelBuilder.Entity<Domain.Entities.Trip.Bus>(entity =>
            {
                entity.Property(x => x.EstadoBus)
                .HasConversion<string>();

                entity.Property(x => x.Placa)
                .HasMaxLength(50)
                .IsRequired();
            }); 

            modelBuilder.Entity<Ruta>()
                .Property(x=> x.EstadoRuta)
                .HasConversion<string>();

            modelBuilder.Entity<Incidencia>(entity =>
            {
                entity.Property(x => x.TipoIncidencia)
                .HasConversion<string>();
                entity.Property(x => x.EstadoIncidencia)
                .HasConversion<string>();
            });

            modelBuilder.Entity<Viaje>()
                .Property(x => x.EstadoViaje)
                .HasConversion<string>();

            modelBuilder.Entity<Conductor>()
                .Property(x => x.Licencia)
                .HasMaxLength(30)
                .IsRequired();

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.Property(x => x.Nombre)
                .HasMaxLength(100);

                entity.Property(x => x.Email)
                .HasMaxLength(100)
                .IsRequired();

                entity.Property(x => x.PasswordHash)
                .HasMaxLength(255)
                .IsRequired();

                entity.Property(x => x.Estado)
                .HasConversion<string>();

            });

            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                if (typeof(AuditEntity).IsAssignableFrom(entityType.ClrType))
                {
                   modelBuilder.Entity(entityType.ClrType)
                        .Property(nameof(AuditEntity.CreatedBy))
                        .HasMaxLength(100);
                }
            }
        }

    }
}
