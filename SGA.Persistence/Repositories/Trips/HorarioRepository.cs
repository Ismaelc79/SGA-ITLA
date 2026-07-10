using Microsoft.EntityFrameworkCore;
using SGA.Domain.Entities.Configuration;
using SGA.Persistence.Context;
using SGA.Persistence.Interfaces;
using SGA.Persistence.Repositories.Common;

namespace SGA.Persistence.Repositories.Trips
{
    public class HorarioRepository : BaseRepository<Horario>, IHorarioRepository
    {
        public HorarioRepository(SGADB context) : base(context)
        {
                        
        }

        public async Task<Horario?> GetByRutaDiaHoraAsync(int rutaId, string diasOperacion, DateTime HoraInicio)
        {
           return await _dbSet.FirstOrDefaultAsync(h =>
           h.RutaId == rutaId &&
           h.DiasOperacion == diasOperacion &&
           h.HoraInicio == HoraInicio); 
        }
    }
}
