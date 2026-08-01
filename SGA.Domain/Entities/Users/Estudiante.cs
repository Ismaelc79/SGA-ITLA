using SGA.Domain.Base;
using SGA.Domain.Entities.Authorization;
using SGA.Domain.Enums;

namespace SGA.Domain.Entities.Users
{
    public class Estudiante : AuditEntity
    {
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
        public string Nombre { get; set; }
        public string Matricula { get; set; }
        public string Carrera { get; set; }
        public string PeriodoAcademico { get; set; }
        public ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
        public ICollection<TarjetaRecargable> TarjetasRecargables { get; set; } = new List<TarjetaRecargable>();
        public ICollection<Pago> Pagos { get; set; } = new List<Pago>();

    }
}
