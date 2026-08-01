using SGA.Domain.Base;
using SGA.Domain.Entities.Trip;
using SGA.Domain.Enums;

namespace SGA.Domain.Entities.Configuration
{
    public class Horario : AuditEntity
    {
        public int RutaId { get; set; }
        public Ruta Ruta { get; set; }
        public DiasOperacion DiasOperacion { get; set; }
        public TimeOnly HoraInicio { get; set; }
        public TimeOnly HoraFin { get; set; }
        public ICollection<Viaje> Viajes { get; set; } = new List<Viaje>();

    }
}
