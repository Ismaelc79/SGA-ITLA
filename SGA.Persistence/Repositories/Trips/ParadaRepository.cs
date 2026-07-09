using Microsoft.EntityFrameworkCore;
using SGA.Domain.Entities.Configuration;
using SGA.Persistence.Context;
using SGA.Persistence.Interfaces.Trips;
using SGA.Persistence.Repositories.Common;

namespace SGA.Persistence.Repositories.Trips
{
    public class ParadaRepository : BaseRepository<Parada>, IParadaRepository
    {
        public ParadaRepository(SGADB context) : base(context)
        {

        }
        public async Task<Parada?> GetByNombreAsync(string nombre)
        { 
            return await _dbSet.FirstOrDefaultAsync(x => x.Nombre == nombre);
        }
    }
}
