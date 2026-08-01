using SGA.Domain.Base;
using SGA.Domain.Enums;

namespace SGA.Domain.Entities.Trip
{
    public class Incidencia : AuditEntity
    {
        public int ReporteId { get; set; }
        public TipoIncidencia TipoIncidencia { get; set; }
        public EstadoIncidencia EstadoIncidencia { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaReporte { get; set; }
        public ICollection<Viaje> Viajes { get; set; } = new List<Viaje>();
    }
}
