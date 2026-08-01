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

        public override async Task<List<Viaje>> GetAllAsync()
        {
            return await _dbSet
                .Include(x => x.Ruta)
                .Include(x => x.Autobus)
                .Include(x => x.Conductor)
                .Include(x => x.Horario)
                .Include(x => x.Incidencia)
                .ToListAsync();
        }

        public override async Task<Viaje?> GetByIdAsync(int id)
        {
            return await _dbSet
                .Include(x => x.Ruta)
                .Include(x => x.Autobus)
                .Include(x => x.Conductor)
                .Include(x => x.Horario)
                .Include(x => x.Incidencia)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Viaje>> GetByEstadoAsync(EstadoViaje estado)
        {
            return await _dbSet
                .Include(x => x.Ruta)
                .Include(x => x.Autobus)
                .Include(x => x.Conductor)
                .Include(x => x.Horario)
                .Include(x => x.Incidencia)
                .Where(x => x.EstadoViaje == estado)
                .ToListAsync();
        }
    }
}
