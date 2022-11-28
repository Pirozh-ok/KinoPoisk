using KinoPoisk.DomainLayer.DTOs;

namespace KinoPoisk.DomainLayer.Interfaces {
    public interface IService<TTypeId, TGetDTO>
    {
        public Task<Result> CreateAsync(ICreateDTO createDto);
        public Task<Result> DeleteAsync(TTypeId id);
        public Task<Result> UpdateAsync(IUpdateDTO<TTypeId> updateDto);
        public Task<Result> GetAllAsync();
        public Task<Result> GetByIdAsync(TTypeId  Id); 
    }
}
