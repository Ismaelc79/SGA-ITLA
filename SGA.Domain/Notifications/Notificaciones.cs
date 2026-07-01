using SGA.Domain.Base;
using SGA.Domain.Enums;

namespace SGA.Domain.Notifications
{
    public class Notificaciones : AuditEntity
    {
        public int UsuarioId { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public TipoNotificacion TipoNotificacion { get; set; }
        public DateTime FechaHora { get; set; }
    }
}
