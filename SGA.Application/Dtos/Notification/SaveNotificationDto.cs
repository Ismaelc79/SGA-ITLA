namespace SGA.Application.Dtos.Notification
{
    public class SaveNotificationDto
    {
        public string Message { get; set; }
        public int UserId { get; set; } // Para saber a quién va la notificación
    }
}