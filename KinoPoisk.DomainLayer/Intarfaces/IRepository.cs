using System.Linq.Expressions;

namespace KinoPoisk.DomainLayer.Intarfaces {
    public interface IRepository { }

    public interface IRepository<TEntity> : IRepository
        where TEntity : class {
        bool Any(Expression<Func<TEntity, bool>> filter);

        IQueryable<TEntity> Get(bool tracking = false);
        IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> expression, bool tracking = false);

        TEntity? FindTracking(Expression<Func<TEntity, bool>> expression, params Expression<Func<TEntity, object>>[] inclusions);
        TEntity? FindNoTracking(Expression<Func<TEntity, bool>> expression, params Expression<Func<TEntity, object>>[] inclusions);

        TEntity? FindById(object id);

        TEntity Add(TEntity item);
        IEnumerable<TEntity> Add(IEnumerable<TEntity> items);

        TEntity Update(TEntity item);
        IEnumerable<TEntity> Update(IEnumerable<TEntity> items);

        TEntity Remove(TEntity item);
        IEnumerable<TEntity> Remove(IEnumerable<TEntity> items);
    }
}

