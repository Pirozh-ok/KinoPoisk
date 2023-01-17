using System.Linq.Expressions;

namespace KinoPoisk.DomainLayer.Intarfaces {
    public interface IRepository<TEntity>
        where TEntity : class {
        IQueryable<TEntity> GetAll();
        TEntity? GetById<TTypeId>(TTypeId id); 
        Task CreateAsync(TEntity item);
        void Update(TEntity item);
        void Delete(TEntity item);
        Task<bool> AnyAsync(Expression<Func<TEntity, bool>> filter);
        Task<TEntity?> GetByFilter(Expression<Func<TEntity, bool>> filter);
        Task<TEntity?> GetByFilterInclude(Expression<Func<TEntity, bool>> filter, Expression<Func<TEntity, object>> includeExpression);
        IQueryable<TEntity> GetAllByFilter(Expression<Func<TEntity, bool>> filter);
        Task<bool> Contains(TEntity item);
    }
}

