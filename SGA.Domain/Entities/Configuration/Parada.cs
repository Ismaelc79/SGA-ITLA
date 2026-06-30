using SGA.Domain.Base;

namespace SGA.Domain.Entities.Configuration
{
    public class Parada : AuditEntity
    {
        public int RutaId { get; set; }
        public string Nombre { get; set; }
        public string Ubicacion { get; set; }
        public string ParadaOrden { get; set; }
        public string Estado { get; set; }
    }
}
