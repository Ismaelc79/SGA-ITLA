using SGA.Domain.Base;
using SGA.Domain.Entities.Trip;
using SGA.Domain.Entities.Users;

namespace SGA.Domain.Entities.Authorization
{
    public class RegistroAcceso : AuditEntity
    {
        public int ViajeId { get; set; }
        public Viaje Viaje { get; set; }
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
        public int AutorizacionId { get; set; }
        public Autorizacion Autorizacion { get; set; }
        public DateTime FechaHora { get; set; }
        public string Motivo { get; set; }
        public bool Resultado { get; set; }
    }
}
