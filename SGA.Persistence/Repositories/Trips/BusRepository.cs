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

        public override async Task<List<Bus>> GetAllAsync()
        {
            return await _dbSet
                .Include(x => x.Conductor)
                .Include(x => x.Ruta)
                .ToListAsync();
       
        }

        public override async Task<Bus?> GetByIdAsync(int id)
        {
            return await _dbSet
                .Include(x => x.Conductor)
                .Include (x => x.Ruta)
                .FirstOrDefaultAsync(x => x.Id == id);

        }

        public async Task<IEnumerable<Bus>> GetByActivosAsync()
        {
            return await _dbSet
                .Include(x =>x.Conductor)
                .Include(x => x.Ruta)
                .Where(x => x.EstadoBus == EstadoBus.Disponible)
                .ToListAsync();
        }

        public async Task<Bus?> GetByPlacaAsync(string placa)
        {
            return await _dbSet
                .Include(x => x.Conductor)
                .Include(x => x.Ruta)
                .FirstOrDefaultAsync(x=> x.Placa == placa);
        }
    }
}
