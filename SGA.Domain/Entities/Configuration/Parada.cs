using SGA.Domain.Base;
using SGA.Domain.Entities.Authorization;

namespace SGA.Domain.Entities.Configuration
{
    public class Parada : AuditEntity
    {
        public int RutaId { get; set; }
        public Ruta Ruta { get; set; }
        public string Nombre { get; set; }
        public string Ubicacion { get; set; }
        public string OrdenParada { get; set; }
        public string Estado { get; set; }
        public ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();

    }
}
