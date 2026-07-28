using SGA.Domain.Entities.Trip;
using SGA.Persistence.Context;
using SGA.Persistence.Interfaces.Trips;
using SGA.Persistence.Repositories.Common;
using Microsoft.EntityFrameworkCore;
using SGA.Domain.Enums;

namespace SGA.Persistence.Repositories.Trips
{
    public class BusRepository : BaseRepository<Bus>, IBusRepository
    {
        public BusRepository(SGADB context) : base(context)
        {
            
        }

        public async Task<IEnumerable<Bus>> GetByActivosAsync()
        {
            return await _dbSet
                .Where(x => x.EstadoBus == EstadoBus.Disponible)
                .ToListAsync();
        }

        public async Task<Bus?> GetByPlacaAsync(string placa)
        {
            return await _dbSet.FirstOrDefaultAsync(x=> x.Placa == placa);
        }
    }
}
