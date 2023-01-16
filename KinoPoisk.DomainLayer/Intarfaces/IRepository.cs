using System.Linq.Expressions;

namespace KinoPoisk.DomainLayer.Intarfaces {
    public interface IRepository<TEntity>
        where TEntity : class {
        IQueryable<TEntity> GetAll();
        TEntity? GetById<TTypeId>(TTypeId id); 
        Task Create(TEntity item);
        void Update(TEntity item);
        void Delete(TEntity item);
        Task<bool> Any(Expression<Func<TEntity, bool>> filter);
        Task<TEntity?> GetByFilter(Expression<Func<TEntity, bool>> filter);
        IQueryable<TEntity> GetAllByFilter(Expression<Func<TEntity, bool>> filter);
        Task<bool> Contains(TEntity item);
    }
}

