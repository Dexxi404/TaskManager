using Microsoft.EntityFrameworkCore;
using TaskManager.Data;
using TaskManager.GenricInterface;

namespace TaskManager.GenricRepository
{
    public class TasksGenricRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly TaskManagerContext _context;
        private readonly DbSet<T> _dbSet;
        public TasksGenricRepository(TaskManagerContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }
    }
}
