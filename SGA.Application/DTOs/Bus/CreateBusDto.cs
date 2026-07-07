
using SGA.Domain.Enums;

namespace SGA.Application.DTOs.Bus
{
    public class CreateBusDto
    {   
        public int ConductorId { get; set; }
        public string Placa { get; set; }
        public int Capacidad { get; set; }

    }
}
