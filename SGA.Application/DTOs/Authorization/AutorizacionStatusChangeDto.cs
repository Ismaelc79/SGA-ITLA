using SGA.Domain.Enums;

namespace SGA.Application.DTOs.Authorization
{
    public class AutorizacionStatusChangeDto
    {
        public EstadoAutorizacion Estado { get; set; }
        public string? Motivo { get; set; }
    }
}
