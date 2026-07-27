using SGA.Domain.Enums;

namespace SGA.Application.DTOs.Notification
{
    public class NotificationDto
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public int UserId { get; set; }
        public TipoNotificacion TipoNotificacion { get; set; }
        public DateTime FechaHora { get; set; }
    }
}
