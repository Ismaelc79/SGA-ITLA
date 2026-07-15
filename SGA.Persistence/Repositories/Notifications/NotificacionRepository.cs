using SGA.Persistence.Repositories.Common;
using SGA.Persistence.Context;
using SGA.Persistence.Interfaces.Notifications;
using SGA.Domain.Notifications;

namespace SGA.Persistence.Repositories.Notifications
{
    public class NotificacionRepository : BaseRepository<Notificaciones>, INotificacionRepository
    {
        public NotificacionRepository(SGADB context) : base(context)
        {

        }
    }
}