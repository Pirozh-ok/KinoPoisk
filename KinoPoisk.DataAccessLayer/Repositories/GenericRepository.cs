using KinoPoisk.DomainLayer.Intarfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace KinoPoisk.DataAccessLayer.Repositories {
    public class GenericRepository<TEntity> : IRepository<TEntity>
        where TEntity : class {
        private DbSet<TEntity> _dbSet;

        public GenericRepository(DbSet<TEntity> dbSet) {
            _dbSet = dbSet; 
        }

        public async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> filter) {
            return await _dbSet.AnyAsync(filter); 
        }

        public async Task CreateAsync(TEntity item) {
            await _dbSet.AddAsync(item);
        }

        public void Delete(TEntity item) {
            _dbSet.Remove(item);
        }

        public IQueryable<TEntity> GetAll() {
            return _dbSet
                .AsNoTracking(); 
        }

        public TEntity? GetById<TTypeId>(TTypeId id) {
            return _dbSet.Find(id);
        }

        public void Update(TEntity item) {
            _dbSet.Update(item);
        }

        public async Task<TEntity?> GetByFilter(Expression<Func<TEntity, bool>> filter) {
            return await _dbSet.SingleOrDefaultAsync(filter);
        }

        public IQueryable<TEntity> GetAllByFilter(Expression<Func<TEntity, bool>> filter) {
            return _dbSet.Where(filter);
        }

        public async Task<bool> Contains(TEntity item) {
            return await _dbSet.ContainsAsync(item);
        }
    }
}