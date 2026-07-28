using SGA.Domain.Entities.Authorization;
using SGA.Persistence.Context;
using SGA.Persistence.Interfaces.Autorizations;
using SGA.Persistence.Repositories.Common;

namespace SGA.Persistence.Repositories.Autorizations
{
    public class AutorizacionRepository : BaseRepository<Autorizacion> , IAutorizacionRepository
    {
        public AutorizacionRepository(SGADB context) : base(context)
        {
        }
    }
}
