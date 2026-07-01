using SGA.Domain.Entities.Trip;
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
    }
}
