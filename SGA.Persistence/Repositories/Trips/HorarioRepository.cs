using Microsoft.EntityFrameworkCore;
using SGA.Domain.Entities.Configuration;
using SGA.Domain.Enums;
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

        public async Task<Horario?> GetByRutaDiaHoraAsync(int Id, int rutaId, DiasOperacion diasOperacion, TimeOnly HoraInicio)
        {
           return await _dbSet.FirstOrDefaultAsync(h =>
           h.Id == Id &&
           h.RutaId == rutaId &&
           h.DiasOperacion == diasOperacion &&
           h.HoraInicio == HoraInicio); 
        }
    }
}
