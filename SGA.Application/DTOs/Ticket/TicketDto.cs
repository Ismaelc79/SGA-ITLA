
using SGA.Domain.Enums;

namespace SGA.Application.DTOs.Ticket
{
    public class TicketDto
    {
        public int Id { get; set; }
        public int EstudianteId { get; set; }
        public string? EstudianteNombre { get; set; }
        public int RutaId { get; set; }
        public string? RutaNombre { get; set; }
        public int ParadaId { get; set; }
        public string? ParadaNombre { get; set; }
        public int PagoId { get; set; }
        public string Tipo { get; set; }
        public EstadoTicket EstadoTicket { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaCierre { get; set; }
    }
}
