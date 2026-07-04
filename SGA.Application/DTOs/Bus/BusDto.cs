
using SGA.Domain.Enums;

namespace SGA.Application.DTOs.Bus
{
    public class BusDto
    {
        public string Id { get; set; }
        public string Placa { get; set; } 
        public int Capacidad { get; set; }
        public EstadoBus EstadoBus { get; set; }
    }
}
