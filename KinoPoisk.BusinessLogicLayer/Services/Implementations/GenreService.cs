using KinoPoisk.DomainLayer.Entities;
using KinoPoisk.DomainLayer.Intarfaces.Services;
using KinoPoisk.DomainLayer.DTOs.GenreDTO;
using AutoMapper;

namespace KinoPoisk.BusinessLogicLayer.Services.Implementations {
    public class GenreService : GenericService<Genre, Guid, CreateGenreDto, UpdateGenreDTO, GetGenreDTO> {
        public GenreService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper) {
        }
    }
}
