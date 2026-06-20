using SGA.Domain.Base;

namespace SGA.Domain.Entities.Trip
{
    public class Incidencia : AuditEntity
    {
        public int IncidenciaId { get; set; }
        public int ViajeId { get; set; }
        public int ReporteId { get; set; }
        public string Tipo { get; set; }
        public string Estado { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaReporte { get; set; }
    }
}
