using SGA.Domain.Entities.Trip;
using SGA.Persistence.Context;
using SGA.Persistence.Interfaces.Trips;
using SGA.Persistence.Repositories.Common;

namespace SGA.Persistence.Repositories.Trips
{
    public class IncidenciaRepository : BaseRepository<Incidencia>, IIncidenciaRepository
    {
        public IncidenciaRepository(SGADB context) : base(context)
        {
        }
    }
}
