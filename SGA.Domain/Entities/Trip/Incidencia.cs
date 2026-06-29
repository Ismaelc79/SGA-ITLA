using SGA.Domain.Base;
using SGA.Domain.Enums;

namespace SGA.Domain.Entities.Trip
{
    public class Incidencia : AuditEntity
    {
        public int ViajeId { get; set; }
        public int ReporteId { get; set; }
        public TipoIncidencia TipoIncidencia { get; set; }
        public string Estado { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaReporte { get; set; }
    }
}
