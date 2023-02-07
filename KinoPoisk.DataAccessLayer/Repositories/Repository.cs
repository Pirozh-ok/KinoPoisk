using KinoPoisk.DomainLayer.Intarfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace KinoPoisk.DataAccessLayer.Repositories {
    public class Repository<TEntity> : IRepository<TEntity>
        where TEntity : class {
        protected DbSet<TEntity> _data;
        protected ApplicationDbContext _context;

        public Repository(ApplicationDbContext context) {
            _context = context;
            _data = context.Set<TEntity>();
        }

        public bool Any(Expression<Func<TEntity, bool>> filter) {
            return _data.Any(filter); 
        }

        public IQueryable<TEntity> Get(bool tracking = false) {
            return tracking ? _data.AsTracking() : _data.AsNoTracking(); 
        }

        public IQueryable<TEntity>? Get(Expression<Func<TEntity, bool>> expression, bool tracking = false) {
            var data = Get();

            if(data is not null) {
                data = data.Where(expression);
            }

            return data;
        }

        public TEntity? FindById(object id) {
            return _data.Find(id);
        }

        public TEntity? FindTracking(Expression<Func<TEntity, bool>> expr, params Expression<Func<TEntity, object>>[] inclusions) {
            var data = _data.Where(expr);
            data = inclusions.Aggregate(data, (current, inclusion) => current.Include(inclusion));

            return data.FirstOrDefault();
        }

        public TEntity FindNoTracking(Expression<Func<TEntity, bool>> expr, params Expression<Func<TEntity, object>>[] inclusions) {
            var data = _data.AsNoTracking().Where(expr);

            data = inclusions.Aggregate(data, (current, inclusion) => current.Include(inclusion));

            return data.FirstOrDefault();
        }

        public TEntity Add(TEntity item) {
            _data.Add(item);
            return item;
        }

        public IEnumerable<TEntity> Add(IEnumerable<TEntity> items) {
            _data.AddRange(items);
            return items;
        }

        public TEntity Update(TEntity item) {
            _data.Update(item);
            return item;
        }

        public IEnumerable<TEntity> Update(IEnumerable<TEntity> items) {
            _data.UpdateRange(items);
            return items;
        }

        public TEntity Remove(TEntity item) {
            _data.Remove(item);
            return item;
        }

        public IEnumerable<TEntity> Remove(IEnumerable<TEntity> items) {
            _data.RemoveRange(items);
            return items;
        }
    }
}