using KinoPoisk.DomainLayer.DTOs;

namespace KinoPoisk.DomainLayer.Intarfaces {
    public interface IService<TTypeId> {
        public Task<Result> CreateAsync(ICreateDTO createDto);
        public Task<Result> DeleteAsync(TTypeId id);
        public Task<Result> UpdateAsync(IUpdateDTO<TTypeId> updateDto);
        public Task<Result> GetAllAsync();
        public Task<Result> GetByIdAsync(TTypeId id);
    }
}
