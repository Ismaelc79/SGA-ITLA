using SGA.Domain.Base;
using SGA.Domain.Entities.Users;
using SGA.Domain.Enums;

namespace SGA.Domain.Entities.Authorization
{
    public class Pago : AuditEntity
    {
        public int EstudianteId { get; set; }
        public Estudiante Estudiante { get; set; }
        public double MontoPago { get; set; }
        public MetodoPago MetodoPago { get; set; }
        public EstadoPago EstadoPago { get; set; }
        public DateTime FechaHora { get; set; }
        public ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
        public ICollection<TarjetaRecargable> TarjetasRecargables { get; set; } = new List<TarjetaRecargable>();

    }
}
