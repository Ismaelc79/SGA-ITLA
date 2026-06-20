using SGA.Domain.Base;

namespace SGA.Domain.Entities.Users
{
    public class Conductor : AuditEntity
    {
        public int ConductorId { get; set; }
        public string Nombre { get; set; }
        public string Identificacion { get; set; }
        public string EstadoConductor { get; set; }
    }
}
