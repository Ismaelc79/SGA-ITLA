using SGA.Domain.Entities.Users;
using SGA.Persistence.Context;
using SGA.Persistence.Interfaces.Users;
using SGA.Persistence.Repositories.Common;

namespace SGA.Persistence.Repositories.Users
{
    public class EmpleadoRepository : BaseRepository<Empleado>, IEmpleadoRepository
    {
        public EmpleadoRepository(SGADB context) : base(context)
        {
        }
    }
}
