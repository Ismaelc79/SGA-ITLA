using SGA.Domain.Entities.Configuration;    
using SGA.Persistence.Context;
using SGA.Persistence.Interfaces.Trips;
using SGA.Persistence.Repositories.Common;

namespace SGA.Persistence.Repositories.Trips
{
    public class RutaRepository : BaseRepository<Ruta>, IRutaRepository
    {
        public RutaRepository(SGADB context) : base(context)
        {
        }
    }
}
