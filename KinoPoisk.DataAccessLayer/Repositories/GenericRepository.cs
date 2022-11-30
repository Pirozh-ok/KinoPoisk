using KinoPoisk.DomainLayer.Intarfaces;
using Microsoft.EntityFrameworkCore;

namespace KinoPoisk.DataAccessLayer.Repositories {
    public class GenericRepository<TEntity> : IRepository<TEntity>
        where TEntity : class {
        private DbSet<TEntity> _dbSet;

        public GenericRepository(DbSet<TEntity> dbSet) {
            _dbSet = dbSet;
        }

        public void Create(TEntity item) {
            _dbSet.Add(item);
        }

        public void Delete(TEntity item) {
            _dbSet.Remove(item);
        }

        public IEnumerable<TEntity> GetAll() {
            return _dbSet.AsNoTracking().ToList();
        }

        public TEntity GetById<TTypeId>(TTypeId id) {
            return _dbSet.Find(id);
        }

        public void Update(TEntity item) {
            //_context.Entry(item).State = EntityState.Modified;
        }
    }
}