using KinoPoisk.DataAccessLayer.Repositories;
using KinoPoisk.DomainLayer.Intarfaces;
using KinoPoisk.DomainLayer.Intarfaces.Services;

namespace KinoPoisk.DataAccessLayer {
    public class UnitOfWork : IUnitOfWork { 
        private Dictionary<string, object> _repositories; 
        private ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context) {
            _context = context;
            _repositories = new Dictionary<string, object>(); 
        }

        public IRepository<TEntity> GetRepository<TEntity>() where TEntity : class {
            string name = typeof(TEntity).GetType().Name;

            if (!_repositories.ContainsKey(name)) {
                _repositories[name] = new GenericRepository<TEntity>(_context.Set<TEntity>());
            }

            return (IRepository<TEntity>)_repositories[name];
        }

        public async Task CommitAsync() {
            await _context.SaveChangesAsync();
        }
    }
}