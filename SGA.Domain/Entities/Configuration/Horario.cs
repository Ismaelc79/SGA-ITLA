using SGA.Domain.Base;

namespace SGA.Domain.Entities.Configuration
{
    public class Horario : AuditEntity
    {
        public int RutaId { get; set; }
        public string DiasOperacion { get; set; }
        public DateTime HoraInicio { get; set; }
        public DateTime HoraFin { get; set; }

    }
}
