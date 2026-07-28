
using SGA.Domain.Enums;

namespace SGA.Application.DTOs.TarjetaRecargable
{
    public class UpdateTarjetaRecargableDto
    {
        public int Id { get; set; }
        public int EstudianteId { get; set; }
        public int PagoId { get; set; }
        public double MontoTarjeta { get; set; }
        public EstadoTarjeta EstadoTarjeta { get; set; }
        public DateTime FechaVigenteInicio { get; set; }
        public DateTime FechaVigenteFin { get; set; }
    }
}
