using Microsoft.EntityFrameworkCore;
using SGA.Domain.Entities.Authorization;
using SGA.Persistence.Context;
using SGA.Persistence.Interfaces.Autorizations;
using SGA.Persistence.Repositories.Common;

namespace SGA.Persistence.Repositories.Autorizations
{
    public class TicketRepository : BaseRepository<Ticket>, ITicketRepository
    {
        public TicketRepository(SGADB context) : base(context)
        {
        }

        public override async Task<List<Ticket>> GetAllAsync()
        {
            return await _dbSet
                .Include(x => x.Estudiante)
                .Include(x => x.Ruta)
                .Include(x => x.Parada)
                .Include(x => x.Pago)
                .ToListAsync();
        }

        public override async Task<Ticket?> GetByIdAsync(int id)
        {
            return await _dbSet
                .Include(x => x.Estudiante)
                .Include(x => x.Ruta)
                .Include(x => x.Parada)
                .Include(x => x.Pago)
                .FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
