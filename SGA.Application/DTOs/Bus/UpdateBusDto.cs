
using SGA.Domain.Enums;

namespace SGA.Application.DTOs.Bus
{
    public class UpdateBusDto
    {
        public int ConductorId { get; set; }
        public int Capacidad { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public EstadoBus EstadoBus { get; set; }
        public string Placa { get; set; }
    }
}
