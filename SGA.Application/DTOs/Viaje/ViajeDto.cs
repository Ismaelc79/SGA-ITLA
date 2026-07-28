
using SGA.Domain.Enums;

namespace SGA.Application.DTOs.Viaje
{
    public class ViajeDto
    {
        public int Id { get; set; }
        public int RutaId { get; set; }
        public int AutobusId { get; set; }
        public int ConductorId { get; set; }
        public int HorarioId { get; set; }
        public int IncidenciaId { get; set; }
        public EstadoViaje EstadoViaje { get; set; }
        public DateTime? HoraSalidaEstimada { get; set; }
        public DateTime? HoraLlegadaEstimada { get; set; }
        
    }
}
