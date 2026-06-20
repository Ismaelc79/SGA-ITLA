using SGA.Domain.Base;

namespace SGA.Domain.Entities.Users
{
    public class Empleado : AuditEntity
    {
        public int EmpleadoId { get; set; }
        public int UsuarioId { get; set; }
        public string Nombre { get; set; }
        public string Identificacion { get; set; }
        public string Cargo { get; set; }
        public string Departamento { get; set; }
    }
}
