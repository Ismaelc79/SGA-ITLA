using Microsoft.EntityFrameworkCore;
using SGA.Persistence.Base;
using SGA.Persistence.Context;

namespace SGA.Persistence.Repositories.Common
{
    public class BaseRepository<T> : IBaseRepository<T> 
        where T: class

    {
        protected readonly SGADB _context;
        protected readonly DbSet<T> _dbSet;

        public BaseRepository(SGADB context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public virtual async Task<List<T>> GetAllAsync()
        {
         return await _dbSet.ToListAsync();
        }
        public virtual async Task<T?> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public virtual async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
        }
        public virtual async Task UpdateAsync(T entity)
        {
            _dbSet.Update(entity);
            await _context.SaveChangesAsync();
        }

        public virtual async Task DeleteAsync(T entity)
        {
            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
        }  
    }
}
