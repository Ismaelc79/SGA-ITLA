using SGA.Domain.Base;

namespace SGA.Domain.Entities.Authorization
{
    public class TarjetaRecargable : AuditEntity
    {
        public int TarjetaId { get; set; }
        public int EstudianteId { get; set; }
        public double MontoTarjeta { get; set; }
        public DateTime FechaVigenteInicio { get; set; }
        public DateTime FechaVigenteFin { get; set; }
    }
}
