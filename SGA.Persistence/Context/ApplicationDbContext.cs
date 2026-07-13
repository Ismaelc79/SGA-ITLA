using Microsoft.EntityFrameworkCore;
using SGA.Domain.Entities;
using SGA.Domain.Entities.Authorization;
using SGA.Domain.Entities.Configuration;
using SGA.Domain.Entities.Users;
using SGA.Domain.Entities.Trip;
namespace SGA.Persistence.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
            : base(options)
        {

        }

        public DbSet<Autorizacion> Autorizacion { get; set; }
        public DbSet<Pago> Pago { get; set; }
        public DbSet<RegistroAcceso> RegistroAcceso { get; set; }
        public DbSet<TarjetaRecargable> TarjetaRecargable { get; set; }
        public DbSet<Ticket> Ticket { get; set; }

        public DbSet<Bus> Bus { get; set; }
        public DbSet<Horario> Horario { get; set; }
        public DbSet<Parada> Parada { get; set; }
        public DbSet<Ruta> Ruta { get; set; }

        public DbSet<Conductor> Conductor { get; set; }
        public DbSet<Empleado> Empleado { get; set; }
        public DbSet<Estudiante> Estudiante { get; set; }
        public DbSet<Rol> Rol { get; set; }
        public DbSet<Usuario> Usuario { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Autorizacion>().ToTable("Autorizacion");

        }




    }
}
