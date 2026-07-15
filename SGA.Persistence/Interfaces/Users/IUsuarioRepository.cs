using SGA.Domain.Entities.Users;
using SGA.Persistence.Base;

namespace SGA.Persistence.Interfaces.Users
{
    public interface IUsuarioRepository : IBaseRepository<Usuario>
    {
        Task<Usuario> GetByEmailAsync(string email);
    }
}