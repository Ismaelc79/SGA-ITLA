using SGA.Domain.Base;

namespace SGA.Domain.Entities.Users
{
    public class Rol: AuditEntity
    {
        public string Nombre { get; set; }
        public string? Descripcion { get; set; }
    }
}
