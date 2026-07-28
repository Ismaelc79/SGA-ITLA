using SGA.Domain.Entities.Users;
using SGA.Persistence.Context;
using SGA.Persistence.Interfaces.Users;
using SGA.Persistence.Repositories.Common;

namespace SGA.Persistence.Repositories.Users
{
    public class ConductorRepository : BaseRepository<Conductor>, IConductorRepository
    {
        public ConductorRepository(SGADB context) : base(context)
        {
        }
    }
}
