using KinoPoisk.DomainLayer.DTOs.MovieCreatorDTOs;
using KinoPoisk.DomainLayer.DTOs.Pageable;
using KinoPoisk.DomainLayer.Entities;

namespace KinoPoisk.DomainLayer.Intarfaces.Services {
    public interface ICreatorService : ISearchableEntityService<Creator, Guid, CreatorDTO, PageableCreatorRequestDto> {
    }
}
