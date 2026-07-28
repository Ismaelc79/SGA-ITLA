using SGA.Domain.Entities.Authorization;
using SGA.Persistence.Context;
using SGA.Persistence.Interfaces.Autorizations;
using SGA.Persistence.Repositories.Common;

namespace SGA.Persistence.Repositories.Autorizations
{
    public class TarjetaRecargableRepository : BaseRepository<TarjetaRecargable>, ITarjetaRecargableRepository
    {
        public TarjetaRecargableRepository(SGADB context) : base(context)
        {
        }
    }
}
