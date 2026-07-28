using SGA.Domain.Entities.Users;
using SGA.Persistence.Context;
using SGA.Persistence.Interfaces.Users;
using SGA.Persistence.Repositories.Common;

namespace SGA.Persistence.Repositories.Users
{
    public class RolRepository : BaseRepository<Rol>, IRolRepository
    {
        public RolRepository(SGADB context) : base(context)
        {
        }
    }
}
