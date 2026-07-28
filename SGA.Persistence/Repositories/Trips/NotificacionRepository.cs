using SGA.Domain.Notifications;
using SGA.Persistence.Context;
using SGA.Persistence.Interfaces.Trips;
using SGA.Persistence.Repositories.Common;

namespace SGA.Persistence.Repositories.Trips
{
    public class NotificacionRepository : BaseRepository<Notificaciones>, INotificacionRepository
    {
        public NotificacionRepository(SGADB context) : base(context)
        {
        }
    }
}

