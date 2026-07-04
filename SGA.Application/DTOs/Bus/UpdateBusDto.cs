
using SGA.Domain.Enums;

namespace SGA.Application.DTOs.Bus
{
    public class UpdateBusDto
    {
        public string Id { get; set; }
        public string ConductorId { get; set; }
        public int Capacidad { get; set; }
    }
}
