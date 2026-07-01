using SGA.Domain.Base;

namespace SGA.Domain.Entities.Configuration
{
    public class Ruta : AuditEntity
    {
        public int ParadaId { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Estado { get; set; }
        public string RutaOrigen { get; set; }
        public string RutaDestino { get; set; }
    }
}
