using KinoPoisk.DomainLayer.DTOs;

namespace KinoPoisk.DomainLayer.Interfaces {
    public interface IRepository<TEntity, TTypeId>
        where TEntity : class{
        Task<IEnumerable<TEntity>> GetAllAsync(); 
        Task<TEntity> GetByIdAsync(TTypeId id);
        Task CreateAsync(TEntity item);
        Task UpdateAsync(TEntity item);
        Task DeleteAsync(TEntity item);
    }
}
