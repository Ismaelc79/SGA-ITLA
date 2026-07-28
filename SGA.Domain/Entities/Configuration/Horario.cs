using SGA.Domain.Base;
using SGA.Domain.Enums;

namespace SGA.Domain.Entities.Configuration
{
    public class Horario : AuditEntity
    {
        public int RutaId { get; set; }
        public DiasOperacion DiasOperacion { get; set; }
        public TimeOnly HoraInicio { get; set; }
        public TimeOnly HoraFin { get; set; }

    }
}
