using KinoPoisk.DomainLayer.DTOs;

namespace KinoPoisk.DomainLayer.Intarfaces {
    public interface IService<TTypeId, TEntityDTO>
{
        public Task<Result> CreateAsync(TEntityDTO createDto);
        public Task<Result> DeleteAsync(TTypeId id);
        public Task<Result> UpdateAsync(TEntityDTO updateDto);
        public Task<Result> GetAllAsync<T>();
        public Task<Result> GetByIdAsync<T>(TTypeId id);
    }
}
