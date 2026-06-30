using SGA.Domain.Base;
using SGA.Domain.Enums;

namespace SGA.Domain.Entities.Users
{
    public class Conductor : AuditEntity
    {
        public int UsuarioId { get; set; }
        public string Nombre { get; set; }
        public string Licencia { get; set; }
        
    }
}
