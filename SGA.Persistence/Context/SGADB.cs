using Microsoft.EntityFrameworkCore;
using SGA.Domain.Entities.Authorization;
using SGA.Domain.Entities.Configuration;
using SGA.Domain.Entities.Users;
using SGA.Domain.Entities.Trip;
using SGA.Domain.Base;
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
            modelBuilder.Entity<Pago>().ToTable("Pago");
            modelBuilder.Entity<RegistroAcceso>().ToTable("RegistroAcceso");
            modelBuilder.Entity<TarjetaRecargable>().ToTable("TarjetaRecargable");
            modelBuilder.Entity<Ticket>().ToTable("Ticket");

            modelBuilder.Entity<Bus>().ToTable("Bus");
            modelBuilder.Entity<Horario>().ToTable("Horario");
            modelBuilder.Entity<Parada>().ToTable("Parada");
            modelBuilder.Entity<Ruta>().ToTable("Ruta");
            modelBuilder.Entity<Incidencia>().ToTable("Incidencia");
            modelBuilder.Entity<Viaje>().ToTable("Viaje");

            modelBuilder.Entity<Conductor>().ToTable("Conductor");
            modelBuilder.Entity<Empleado>().ToTable("Empleado");
            modelBuilder.Entity<Estudiante>().ToTable("Estudiante");
            modelBuilder.Entity<Rol>().ToTable("Rol");
            modelBuilder.Entity<Usuario>().ToTable("Usuario");
            modelBuilder.Entity<Notificaciones>().ToTable("Notificaciones");

            modelBuilder.Entity<Autorizacion>(entity =>
            {
                entity.Property(x => x.EstadoAutorizacion)
                .HasConversion<string>();

                entity.HasOne(x => x.Usuario)
                .WithMany(u => u.Autorizaciones)
                .HasForeignKey(x => x.UsuarioId)
                .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<RegistroAcceso>(entity =>
            {
                entity.HasOne(x => x.Viaje)
                .WithMany(v => v.RegistrosAcceso)
                .HasForeignKey(x => x.ViajeId)
                .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(x => x.Usuario)
                .WithMany(u => u.RegistrosAcceso)
                .HasForeignKey(x => x.UsuarioId)
                .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(x => x.Autorizacion)
                .WithMany(a => a.RegistrosAcceso)
                .HasForeignKey(x => x.AutorizacionId)
                .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Pago>(entity =>
            {
                entity.Property(x => x.MetodoPago)
                .HasConversion<string>();

                entity.Property(x => x.EstadoPago)
                .HasConversion<string>();

                entity.Property(x => x.MontoPago)
                .HasPrecision(18, 2);

                entity.HasOne(x => x.Estudiante)
                .WithMany(e => e.Pagos)
                .HasForeignKey(x => x.EstudianteId)
                .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<TarjetaRecargable>(entity =>
            {
                entity.Property(x => x.EstadoTarjeta)
                .HasConversion<string>();

                entity.Property(x => x.MontoTarjeta)
                .HasPrecision(18, 2);

                entity.HasOne(x => x.Estudiante)
                .WithMany(e => e.TarjetasRecargables)
                .HasForeignKey(x => x.EstudianteId)
                .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(x => x.Pago)
                .WithMany(p => p.TarjetasRecargables)
                .HasForeignKey(x => x.PagoId)
                .OnDelete(DeleteBehavior.Restrict);

            });

            modelBuilder.Entity<Ticket>(entity =>
            {
                entity.Property(x => x.EstadoTicket)
                .HasConversion<string>();

                entity.HasOne(x => x.Estudiante)
                .WithMany(e => e.Tickets)
                .HasForeignKey(x => x.EstudianteId)
                .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(x => x.Ruta)
                .WithMany(r => r.Tickets)
                .HasForeignKey(x => x.RutaId)
                .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(x => x.Parada)
                .WithMany(p => p.Tickets)
                .HasForeignKey(x => x.ParadaId)
                .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(x => x.Pago)
                .WithMany(p => p.Tickets)
                .HasForeignKey(x => x.PagoId)
                .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Horario>(entity =>
            {
                entity.Property(x => x.DiasOperacion)
                .HasConversion<string>();

                entity.HasOne(b => b.Ruta)
                .WithMany(c => c.Horarios)
                .HasForeignKey(b => b.RutaId)
                .OnDelete(DeleteBehavior.Restrict);
            });
  
            modelBuilder.Entity<Bus>(entity =>
            {
                entity.Property(x => x.EstadoBus)
                .HasConversion<string>();

                entity.Property(x => x.Placa)
                .HasMaxLength(50)
                .IsRequired();

                entity.HasOne(x => x.Conductor)
                .WithMany(b => b.Buses)
                .HasForeignKey(x => x.ConductorId)
                .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(x => x.Ruta)
                .WithMany(b => b.Buses)
                .HasForeignKey(x => x.RutaId)
                .OnDelete(DeleteBehavior.Restrict);
            }); 

            modelBuilder.Entity<Ruta>()
                .Property(x=> x.EstadoRuta)
                .HasConversion<string>();

            modelBuilder.Entity<Parada>(entity =>
            {
                entity.HasOne(x => x.Ruta)
                .WithMany(b => b.Paradas)
                .HasForeignKey(x =>x.RutaId)
                .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Incidencia>(entity =>
            {
                entity.Property(x => x.TipoIncidencia)
                .HasConversion<string>();
                entity.Property(x => x.EstadoIncidencia)
                .HasConversion<string>();
            });

            modelBuilder.Entity<Viaje>(entity =>
            {
                entity.Property(x => x.EstadoViaje)
                .HasConversion<string>();

                entity.HasOne(x => x.Ruta)
                .WithMany(r => r.Viajes)
                .HasForeignKey(x => x.RutaId)
                .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(x => x.Autobus)
                .WithMany(b => b.Viajes)
                .HasForeignKey(x => x.AutobusId)
                .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(x => x.Conductor)
                .WithMany(c => c.Viajes)
                .HasForeignKey(x => x.ConductorId)
                .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(x => x.Horario)
                .WithMany(h => h.Viajes)
                .HasForeignKey(x => x.HorarioId)
                .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(x => x.Incidencia)
                .WithMany(i => i.Viajes)
                .HasForeignKey(x => x.IncidenciaId)
                .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Conductor>(entity =>
            {
                entity.Property(x => x.Licencia)
                .HasMaxLength(30)
                .IsRequired();

                entity.HasOne(x => x.Usuario)
                .WithMany(u => u.Conductores)
                .HasForeignKey(x => x.UsuarioId)
                .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Empleado>(entity =>
            {
                entity.HasOne(x => x.Usuario)
                .WithMany(u => u.Empleados)
                .HasForeignKey(x => x.UsuarioId)
                .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Estudiante>(entity =>
            {
                entity.HasOne(x => x.Usuario)
                .WithMany(u => u.Estudiantes)
                .HasForeignKey(x => x.UsuarioId)
                .OnDelete(DeleteBehavior.Restrict);
            });

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

                entity.HasOne(x => x.Rol)
                .WithMany(r => r.Usuarios)
                .HasForeignKey(x => x.RolId)
                .OnDelete(DeleteBehavior.Restrict);

            });

            modelBuilder.Entity<Notificaciones>(entity =>
            {
                entity.HasOne(x => x.Usuario)
                .WithMany(u => u.Notificaciones)
                .HasForeignKey(x => x.UsuarioId)
                .OnDelete(DeleteBehavior.Restrict);
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
