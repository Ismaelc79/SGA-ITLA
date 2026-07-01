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
    }
}
