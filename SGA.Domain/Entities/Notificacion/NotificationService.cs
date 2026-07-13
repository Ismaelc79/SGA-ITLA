using SGA.Domain.Entities.Users;

namespace SGA.Domain.Notifications
{
    public class Notificacion
    {
        public int Id { get; set; }

        public string Message { get; set; }

        public bool IsRead { get; set; }

        public int UserId { get; set; }

        public Usuario Usuario { get; set; }
    }
}