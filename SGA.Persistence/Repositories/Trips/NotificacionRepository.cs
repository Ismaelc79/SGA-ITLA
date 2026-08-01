using Microsoft.EntityFrameworkCore;
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

        public override async Task<List<Notificaciones>> GetAllAsync()
        {
            return await _dbSet
                .Include(x => x.Usuario)
                .ToListAsync();
        }

        public override async Task<Notificaciones?> GetByIdAsync(int id)
        {
            return await _dbSet
                .Include(x => x.Usuario)
                .FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}

