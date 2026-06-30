using SGA.Domain.Base;
using SGA.Domain.Enums;

namespace SGA.Domain.Entities.Authorization
{
    public class Pago : AuditEntity
    {
        public int UsuarioId { get; set; }
        public double MontoPago { get; set; }
        public MetodoPago MetodoPago { get; set; }
        public EstadoPago EstadoPago { get; set; }
        public DateTime FechaHora { get; set; }
        
    }
}
