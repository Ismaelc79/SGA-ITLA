
using SGA.Domain.Enums;

namespace SGA.Application.DTOs.Bus
{
    public class CreateBusDto
    {   
        public int ConductorId { get; set; }
        public int RutaId { get; set; }
        public string Marca {  get; set; }
        public string Modelo { get; set; }
        public string Placa { get; set; }
        public int Capacidad { get; set; }

    }
}
