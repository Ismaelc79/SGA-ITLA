
using SGA.Domain.Enums;

namespace SGA.Application.DTOs.Bus
{
    public class BusStatusChangeDto
    {
        public EstadoBus EstadoBus { get; set; }
        public string? Motivo { get; set; }
    }
}
