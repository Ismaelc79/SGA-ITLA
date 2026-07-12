using SGA.Domain.Base;
using SGA.Domain.Enums;

namespace SGA.Domain.Entities.Trip
{
    public class Bus : AuditEntity
    {
        public int ConductorId { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Placa { get; set; }
        public int Capacidad { get; set; }
        public EstadoBus EstadoBus { get; set; }

    }
}
