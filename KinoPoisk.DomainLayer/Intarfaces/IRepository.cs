using System.Linq.Expressions;

namespace KinoPoisk.DomainLayer.Intarfaces {
    public interface IRepository<TEntity>
        where TEntity : class {
        IQueryable<TEntity> GetAll();
        TEntity? GetById<TTypeId>(TTypeId id); 
        void Create(TEntity item);
        void Update(TEntity item);
        void Delete(TEntity item);
        bool Contains(TEntity item); 
    }
}

