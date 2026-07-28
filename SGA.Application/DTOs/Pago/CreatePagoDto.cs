using SGA.Domain.Enums;

namespace SGA.Application.DTOs.Pago
{
    public class CreatePagoDto
    {
        public int EstudianteId { get; set; }
        public double MontoPago { get; set; }
        public MetodoPago MetodoPago { get; set; }
        public EstadoPago EstadoPago { get; set; }
        public DateTime FechaHora { get; set; }
    }
}
