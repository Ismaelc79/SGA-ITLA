using Microsoft.EntityFrameworkCore;
using SGA.Domain.Entities.Authorization;
using SGA.Persistence.Context;
using SGA.Persistence.Interfaces.Autorizations;
using SGA.Persistence.Repositories.Common;

namespace SGA.Persistence.Repositories.Autorizations
{
    public class AutorizacionRepository : BaseRepository<Autorizacion> , IAutorizacionRepository
    {
        public AutorizacionRepository(SGADB context) : base(context)
        {
        }

        public override async Task<List<Autorizacion>> GetAllAsync()
        {
            return await _dbSet
                .Include(x => x.Usuario)
                .ToListAsync();
        }

        public override async Task<Autorizacion?> GetByIdAsync(int id)
        {
            return await _dbSet
                .Include(x => x.Usuario)
                .FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
