using KinoPoisk.DomainLayer.DTOs;

namespace KinoPoisk.DomainLayer.Interfaces {
    public interface IRepository<TTypeId,TCreateDTO, TUpdateDTO, TGetDTO, TResult>
        where TCreateDTO : ICreateDTO
        where TUpdateDTO : IUpdateDTO<TTypeId>
        where TResult : class{
        Task<TResult> GetAll();
        Task<TResult> GetById(TTypeId id);
        Task<TResult> Create(TCreateDTO dto);
        Task<TResult> Update(TUpdateDTO dto);
        Task<TResult> Delete(TTypeId id);
    }
}
