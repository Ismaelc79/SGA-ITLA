using Microsoft.EntityFrameworkCore;
using SGA.Domain.Entities.Users;
using SGA.Persistence.Context;
using SGA.Persistence.Interfaces.Users;
using SGA.Persistence.Repositories.Common;

namespace SGA.Persistence.Repositories.Users
{
    public class EstudianteRepository : BaseRepository<Estudiante>, IEstudianteRepository
    {
        public EstudianteRepository(SGADB context) : base(context)
        {
        }

        public override async Task<List<Estudiante>> GetAllAsync()
        {
            return await _dbSet
                .Include(x => x.Usuario)
                .ToListAsync();
        }

        public override async Task<Estudiante?> GetByIdAsync(int id)
        {
            return await _dbSet
                .Include(x => x.Usuario)
                .FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
