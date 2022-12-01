using KinoPoisk.DomainLayer.Intarfaces;
using Microsoft.EntityFrameworkCore;

namespace KinoPoisk.DataAccessLayer.Repositories {
    public class GenericRepository<TEntity> : IRepository<TEntity>
        where TEntity : class {
        private DbSet<TEntity> _dbSet;

        public GenericRepository(DbSet<TEntity> dbSet) {
            _dbSet = dbSet;
        }

        public bool Contains(TEntity item) {
            return _dbSet.Contains(item);
        }

        public void Create(TEntity item) {
            _dbSet.Add(item);
        }

        public void Delete(TEntity item) {
            _dbSet.Remove(item);
        }

        public IQueryable<TEntity> GetAll() {
            return _dbSet
                .AsNoTracking(); 
        }

        public TEntity GetById<TTypeId>(TTypeId id) {
            return _dbSet.Find(id);
        }

        public void Update(TEntity item) {
            _dbSet.Update(item);
        }
    }
}