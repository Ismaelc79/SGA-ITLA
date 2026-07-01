using SGA.Domain.Entities.Configuration;
using SGA.Persistence.Context;
using SGA.Persistence.Interfaces.Trips;
using SGA.Persistence.Repositories.Common;

namespace SGA.Persistence.Repositories.Trips
{
    public class BusRepository : BaseRepository<Bus>, IBusRepository
    {
        public BusRepository(SGADB context) : base(context)
        {
        }
    }
}
