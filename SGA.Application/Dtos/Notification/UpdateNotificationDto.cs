using System.ComponentModel.DataAnnotations;

namespace SGA.Application.Dtos.Notification
{
    public class UpdateNotificationDto : SaveNotificationDto
    {
        [Range(1, int.MaxValue, ErrorMessage = "El ID de la notificación es obligatorio")]
        public int Id { get; set; }
    }
}