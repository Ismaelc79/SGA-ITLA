using SGA.Domain.Base;

namespace SGA.Domain.Entities.Configuration
{
    public class Bus : AuditEntity
    {
        public int AutobusId { get; set; }
        public int ConductorId { get; set; }
        public string Placa { get; set; }
        public int Capacidad { get; set; }
        public string Estado { get; set; }

    }
}
