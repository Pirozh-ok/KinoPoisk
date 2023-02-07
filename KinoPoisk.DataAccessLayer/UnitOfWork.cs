using KinoPoisk.DataAccessLayer.Repositories;
using KinoPoisk.DomainLayer.Intarfaces;
using KinoPoisk.DomainLayer.Intarfaces.Services;

namespace KinoPoisk.DataAccessLayer {
    public class UnitOfWork : IUnitOfWork { 
        private Dictionary<string, IRepository> _repositories; 
        private ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context) {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _repositories = new Dictionary<string, IRepository>(); 
        }

        public IRepository<TEntity> GetRepository<TEntity>() where TEntity : class {
            string nameType = typeof(TEntity).Name;

            if (!_repositories.ContainsKey(nameType)) {
                _repositories[nameType] = new Repository<TEntity>(_context);
            }

            return (IRepository<TEntity>)_repositories[nameType];
        }

        public void Commit() {
            _context.SaveChanges();
        }

        public async Task CommitAsync() {
            await _context.SaveChangesAsync();
        }
    }
}