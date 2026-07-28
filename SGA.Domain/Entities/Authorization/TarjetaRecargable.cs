using SGA.Domain.Base;
using SGA.Domain.Enums;

namespace SGA.Domain.Entities.Authorization
{
    public class TarjetaRecargable : AuditEntity
    {
        public int EstudianteId { get; set; }
        public int PagoId { get; set; }
        public double MontoTarjeta { get; set; }
        public EstadoTarjeta EstadoTarjeta { get; set; }
        public DateTime FechaVigenteInicio { get; set; }
        public DateTime FechaVigenteFin { get; set; }
    }
}
