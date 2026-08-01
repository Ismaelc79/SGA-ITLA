using SGA.Domain.Base;
using SGA.Domain.Enums;

namespace SGA.Domain.Entities.Users
{
    public class Empleado : AuditEntity
    {
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
        public string Nombre { get; set; }
        public string Identificacion { get; set; }
        public string Cargo { get; set; }
        public string Departamento { get; set; }

    }
}
