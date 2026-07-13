
using SGA.Domain.Enums;

namespace SGA.Application.DTOs.Viaje
{
    public class CreateViajeDto
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
