using KinoPoisk.BusinessLogicLayer.DTOs;
using KinoPoisk.DataAccessLayer;

namespace KinoPoisk.BusinessLogicLayer.Services.Interfaces
{
    public interface IService<TTypeId>
    {
        public Task CreateAsync(IUpdateOrCreateDto createDto);
        public Task DeleteAsync(TTypeId id);
        public Task UpdateAsync(TTypeId id, IUpdateOrCreateDto updateDto);
        public Task<IEnumerable<IGetDto<TTypeId>>> GetAllAsync();
        public Task<IGetDto<TTypeId>> GetByIdAsync(TTypeId  Id); 
    }
}
