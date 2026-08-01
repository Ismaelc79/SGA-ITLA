using SGA.Domain.Base;
using SGA.Domain.Entities.Authorization;
using SGA.Domain.Enums;
using SGA.Domain.Notifications;

namespace SGA.Domain.Entities.Users
{
    public class Usuario : AuditEntity
    {
        public int RolId { get; set; }
        public Rol Rol { get; set; }
        public string Nombre { get; set; } 
        public string Email { get; set; } 
        public string PasswordHash { get; set; }
        public EstadoUsuario Estado { get; set; }
        public bool EstaRestringido { get; set; }
        public ICollection<Estudiante> Estudiantes { get; set; } = new List<Estudiante>();
        public ICollection<Conductor> Conductores { get; set; } = new List<Conductor>();
        public ICollection<Empleado> Empleados { get; set; } = new List<Empleado>();
        public ICollection<Autorizacion> Autorizaciones { get; set; } = new List<Autorizacion>();
        public ICollection<RegistroAcceso> RegistrosAcceso { get; set; } = new List<RegistroAcceso>();
        public ICollection<Notificaciones> Notificaciones { get; set; } = new List<Notificaciones>();

    }
}
