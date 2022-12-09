using KinoPoisk.DomainLayer.DTOs;

namespace KinoPoisk.DomainLayer.Intarfaces {
    public interface IService<TTypeId>
{
        public Task<Result> CreateAsync<T>(T createDto);
        public Task<Result> DeleteAsync(TTypeId id);
        public Task<Result> UpdateAsync<T>(T updateDto);
        public Task<Result> GetAllAsync<T>();
        public Task<Result> GetByIdAsync<T>(TTypeId id);
    }
}
