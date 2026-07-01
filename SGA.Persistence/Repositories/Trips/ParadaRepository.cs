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
    }
}
