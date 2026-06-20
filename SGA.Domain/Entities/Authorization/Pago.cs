using SGA.Domain.Base;

namespace SGA.Domain.Entities.Authorization
{
    public class Pago : AuditEntity
    {
        public int PagoId { get; set; }
        public int UsuarioId { get; set; }
        public double Monto { get; set; }
        public string MetodoPago { get; set; }
        public DateTime FechaHora { get; set; }
        public string Estado { get; set; }
    }
}
