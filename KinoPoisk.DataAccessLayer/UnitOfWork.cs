using KinoPoisk.DataAccessLayer.Repositories;
using KinoPoisk.DomainLayer.Intarfaces;
using KinoPoisk.DomainLayer.Intarfaces.Services;
using Microsoft.EntityFrameworkCore;

namespace KinoPoisk.DataAccessLayer {
    public class UnitOfWork : IUnitOfWork { 
        private Dictionary<string, object> _repositories; 
        private ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context) {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _repositories = new Dictionary<string, object>(); 
        }

        public IRepository<TEntity> GetRepository<TEntity>() where TEntity : class {
            string nameType = typeof(TEntity).Name;

            if (!_repositories.ContainsKey(nameType)) {
                _repositories[nameType] = new GenericRepository<TEntity>(_context.Set<TEntity>());
            }

            return (IRepository<TEntity>)_repositories[nameType];
        }

        public async Task CommitAsync() {
            await _context.SaveChangesAsync();
        }
    }
}