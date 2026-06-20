using SGA.Domain.Base;

namespace SGA.Domain.Notifications
{
    public class Notificaciones : AuditEntity
    {
        public int NotificacionId { get; set; }
        public int UsuarioId { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Tipo { get; set; }
        public DateTime FechaHora { get; set; }
    }
}
