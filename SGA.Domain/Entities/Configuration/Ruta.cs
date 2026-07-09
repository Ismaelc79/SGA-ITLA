using SGA.Domain.Base;
using SGA.Domain.Enums;

namespace SGA.Domain.Entities.Configuration
{
    public class Ruta : AuditEntity
    {
        public int ParadaId { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public EstadoRuta EstadoRuta { get; set; }
        public string RutaOrigen { get; set; }
        public string RutaDestino { get; set; }
    }
}
