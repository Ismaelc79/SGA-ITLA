

using SGA.Domain.Enums;

namespace SGA.Application.DTOs.Viaje
{
    public class ViajeStatusChangeDto
    {
        public EstadoViaje EstadoViaje { get; set; }
        public string? Motivo { get; set; }
    }
}
