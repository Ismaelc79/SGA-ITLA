using Microsoft.EntityFrameworkCore;
using SGA.Domain.Entities.Authorization;
using SGA.Persistence.Context;
using SGA.Persistence.Interfaces.Autorizations;
using SGA.Persistence.Repositories.Common;

namespace SGA.Persistence.Repositories.Autorizations
{
    public class RegistroAccesoRepository : BaseRepository<RegistroAcceso>, IRegistroAccesoRepository
    {
        public RegistroAccesoRepository(SGADB context) : base(context)
        {
        }

        public override async Task<List<RegistroAcceso>> GetAllAsync()
        {
            return await _dbSet
                .Include(x => x.Viaje)
                .Include(x => x.Usuario)
                .Include(x => x.Autorizacion)
                .ToListAsync();
        }

        public override async Task<RegistroAcceso?> GetByIdAsync(int id)
        {
            return await _dbSet
                .Include(x => x.Viaje)
                .Include(x => x.Usuario)
                .Include(x => x.Autorizacion)
                .FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
