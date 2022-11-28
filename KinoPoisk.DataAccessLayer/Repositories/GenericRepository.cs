using Microsoft.EntityFrameworkCore;

namespace KinoPoisk.DataAccessLayer.Repositories {
    public abstract class GenericRepository<TEntity, TTypeId> : IRepository<TEntity, TTypeId>
        where TEntity : class {
        private ApplicationDbContext _context;
        private DbSet<TEntity> _dbSet;

        public GenericRepository(ApplicationDbContext context) {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        public async Task CreateAsync(TEntity item) {
            await _dbSet.AddAsync(item);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(TEntity item) {
            _dbSet.Remove(item);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync() {
            return await _dbSet.AsNoTracking().ToListAsync();
        }

        public async Task<TEntity> GetByIdAsync(TTypeId id) {
            return await _dbSet.FindAsync(id);
        }

        public async Task UpdateAsync(TEntity item) {
            _context.Entry(item).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
