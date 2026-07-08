
using SGA.Domain.Enums;

namespace SGA.Application.DTOs.Bus
{
    public class UpdateBusDto
    {
        public int Id { get; set; }
        public int ConductorId { get; set; }
        public int Capacidad { get; set; }
        public EstadoBus EstadoBus { get; set; }
        public string Placa { get; set; }
    }
}
