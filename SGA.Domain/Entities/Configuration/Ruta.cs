using SGA.Domain.Base;
using SGA.Domain.Entities.Trip;
using SGA.Domain.Enums;

namespace SGA.Domain.Entities.Configuration
{
    public class Ruta : AuditEntity
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public EstadoRuta EstadoRuta { get; set; }
        public string RutaOrigen { get; set; }
        public string RutaDestino { get; set; }
        public ICollection<Horario> Horarios { get; set; } = new List<Horario>();
        public ICollection<Parada> Paradas { get; set; } = new List<Parada>();
        public ICollection<Bus> Buses { get; set; } = new List<Bus>();
    }
}
