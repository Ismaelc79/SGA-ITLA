using SGA.Domain.Base;
using SGA.Domain.Enums;

namespace SGA.Domain.Entities.Authorization
{
    public class Ticket : AuditEntity
    {
        public int UsuarioId { get; set; }
        public int RutaId { get; set; }
        public int ParadaId { get; set; }
        public int PagoId { get; set; }
        public string Tipo { get; set; }
        public EstadoTicket EstadoTicket { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaCierre { get; set; }
    }
}
