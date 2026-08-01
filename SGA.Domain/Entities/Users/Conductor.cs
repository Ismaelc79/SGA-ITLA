using SGA.Domain.Base;
using SGA.Domain.Entities.Trip;
using SGA.Domain.Enums;

namespace SGA.Domain.Entities.Users
{
    public class Conductor : AuditEntity
    {
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
        public string Nombre { get; set; }
        public string Licencia { get; set; }
        public ICollection<Bus> Buses { get; set; } = new List<Bus>();
        public ICollection<Viaje> Viajes { get; set; } = new List<Viaje>();

    }
}
