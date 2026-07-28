using SGA.Domain.Entities.Configuration;    
using SGA.Persistence.Context;
using SGA.Persistence.Interfaces.Trips;
using SGA.Persistence.Repositories.Common;
using Microsoft.EntityFrameworkCore;
using SGA.Domain.Enums;


namespace SGA.Persistence.Repositories.Trips
{
    public class RutaRepository : BaseRepository<Ruta>, IRutaRepository
    {
        public RutaRepository(SGADB context) : base(context)
        {

        }

       public async Task<IEnumerable<Ruta>> GetByDisponibleAsync()
        {
            return await _dbSet
                .Where(x => x.EstadoRuta == EstadoRuta.Disponible)
                .ToListAsync();
        }

        public async Task<Ruta?> GetByNombreAsync(string nombre)
        {
            return await _dbSet.FirstOrDefaultAsync(x => x.Nombre == nombre);
        }
    }
}
