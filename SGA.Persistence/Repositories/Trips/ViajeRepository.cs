using Microsoft.EntityFrameworkCore;
using SGA.Domain.Entities.Trip;
using SGA.Domain.Enums;
using SGA.Persistence.Context;
using SGA.Persistence.Interfaces.Trips;
using SGA.Persistence.Repositories.Common;

namespace SGA.Persistence.Repositories.Trips
{
    public class ViajeRepository : BaseRepository<Viaje>, IViajeRepository
    {
        public ViajeRepository(SGADB context) : base(context)
        {
        }

        public async Task<IEnumerable<Viaje>> GetByEstadoAsync(EstadoViaje estado)
        {
            return await _dbSet
                .Where(x => x.EstadoViaje == estado)
                .ToListAsync();
        }
    }
}
