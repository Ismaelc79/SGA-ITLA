namespace SGA.Persistence.Repository.Base
{
    public interface IBaseRepository<T> where T : class
    {
      //  protected readonly SGAContext _context;
       // protected readonly DbSet<T> _dbSet;
        Task<T?> GetByIdAsync(int id);

        Task<IEnumerable<T>> GetAllAsync();

        Task AddAsync(T entity);

        Task UpdateAsync(T entity);

        Task DeleteAsync(int id);
    }
}
