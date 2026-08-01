using SGA.Domain.Base;
using SGA.Domain.Entities.Configuration;
using SGA.Domain.Entities.Users;
using SGA.Domain.Enums;

namespace SGA.Domain.Entities.Authorization
{
    public class Ticket : AuditEntity
    {
        public int EstudianteId { get; set; }
        public Estudiante Estudiante { get; set; }
        public int RutaId { get; set; }
        public Ruta Ruta { get; set; }
        public int ParadaId { get; set; }
        public Parada Parada { get; set; }
        public int PagoId { get; set; }
        public Pago Pago { get; set; }
        public string Tipo { get; set; }
        public EstadoTicket EstadoTicket { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaCierre { get; set; }
    }
}
