using KinoPoisk.DomainLayer.Entities;
using KinoPoisk.DomainLayer.Intarfaces.Services;
using AutoMapper;

namespace KinoPoisk.BusinessLogicLayer.Services.Implementations {
    public class GenreService : GenericService<Genre, Guid> {
        public GenreService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper) {
        }
    }
}
