using System.ComponentModel.DataAnnotations;

namespace SGA.Application.Dtos.Notification
{
    public class SaveNotificationDto
    {
        [Required(ErrorMessage = "El mensaje es obligatorio")]
        [StringLength(200, MinimumLength = 3, ErrorMessage = "El mensaje debe tener entre 3 y 200 caracteres")]
        public string Message { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "El usuario es obligatorio")]
        public int UserId { get; set; }
    }
}