

using SGA.Domain.Enums;

namespace SGA.Application.DTOs.Viaje
{
    public class UpdateViajeDto
    {
        public int Id { get; set; }
        public int IncidenciaId { get; set; }
        public EstadoViaje EstadoViaje { get; set; }
        public DateTime? HoraSalidaEstimada { get; set; }
        public DateTime? HoraLlegadaEstimada { get; set; }

    }
}
