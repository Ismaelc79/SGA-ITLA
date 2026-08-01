
using Microsoft.EntityFrameworkCore;
using SGA.Domain.Entities.Authorization;
using SGA.Persistence.Context;
using SGA.Persistence.Interfaces.Autorizations;
using SGA.Persistence.Repositories.Common;


namespace SGA.Persistence.Repositories.Autorizations
{
    public class PagoRepository : BaseRepository<Pago>, IPagoRepository
    {
        public PagoRepository(SGADB context) : base(context)
        {
        }

        public override async Task<List<Pago>> GetAllAsync()
        {
            return await _dbSet
                .Include(x => x.Estudiante)
                .ToListAsync();
        }

        public override async Task<Pago?> GetByIdAsync(int id)
        {
            return await _dbSet
                .Include(x => x.Estudiante)
                .FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
