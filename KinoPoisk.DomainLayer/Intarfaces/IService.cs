using KinoPoisk.DomainLayer.DTOs;

namespace KinoPoisk.DomainLayer.Intarfaces {
    public interface IService<TTypeId, TCreateDTO, TUpdateDTO>
        where TCreateDTO : ICreateDTO
        where TUpdateDTO : IUpdateDTO<TTypeId>{
        public Task<Result> CreateAsync(TCreateDTO createDto);
        public Task<Result> DeleteAsync(TTypeId id);
        public Task<Result> UpdateAsync(TUpdateDTO updateDto);
        public Task<Result> GetAllAsync();
        public Task<Result> GetByIdAsync(TTypeId id);
    }
}
