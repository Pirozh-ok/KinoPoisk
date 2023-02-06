using KinoPoisk.DomainLayer.DTOs.Pageable.Base;

namespace KinoPoisk.DomainLayer.Intarfaces {
    public interface ISearchableEntityService<TEntity, TKey, TDto, TFilters> : IBaseEntityService<TKey, TDto> {
        ServiceResult<PageableBaseResponseDto<T>> SearchFor<T>(TFilters filters);
    }
}
