using SGA.Domain.Base;
using SGA.Domain.Enums;

namespace SGA.Domain.Entities.Trip
{
    public class Viaje : AuditEntity
    {
        public int RutaId { get; set; }
        public int AutobusId { get; set; }
        public int ConductorId { get; set; }
        public int HorarioId { get; set; }
        public EstadoViaje EstadoViaje { get; set; }
        public DateTime? HoraSalidaEstimada { get; set; }
        public DateTime? HoraLlegadaEstimada { get; set; }
        
    }
}
