
using SGA.Domain.Enums;

namespace SGA.Application.DTOs.Bus
{
    public class BusDto
    {
        public int Id { get; set; }
        public int ConductorId { get; set; }
        public string? ConductorNombre  { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Placa { get; set; } 
        public int Capacidad { get; set; }
        public EstadoBus EstadoBus { get; set; }
    }
}
