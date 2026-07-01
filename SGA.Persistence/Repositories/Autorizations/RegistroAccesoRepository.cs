using SGA.Domain.Entities.Authorization;
using SGA.Persistence.Context;
using SGA.Persistence.Interfaces.Autorizations;
using SGA.Persistence.Repositories.Common;

namespace SGA.Persistence.Repositories.Autorizations
{
    public class RegistroAccesoRepository : BaseRepository<RegistroAcceso>, IRegistroAccesoRepository
    {
        public RegistroAccesoRepository(SGADB context) : base(context)
        {
        }
    }
}
