using Microsoft.EntityFrameworkCore;
using SGA.Domain.Entities.Authorization;
using SGA.Persistence.Context;
using SGA.Persistence.Interfaces.Autorizations;
using SGA.Persistence.Repositories.Common;

namespace SGA.Persistence.Repositories.Autorizations
{
    public class TarjetaRecargableRepository : BaseRepository<TarjetaRecargable>, ITarjetaRecargableRepository
    {
        public TarjetaRecargableRepository(SGADB context) : base(context)
        {
        }

        public override async Task<List<TarjetaRecargable>> GetAllAsync()
        {
            return await _dbSet
                .Include(x => x.Estudiante)
                .Include(x => x.Pago)
                .ToListAsync();
        }

        public override async Task<TarjetaRecargable?> GetByIdAsync(int id)
        {
            return await _dbSet
                .Include(x => x.Estudiante)
                .Include(x => x.Pago)
                .FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
