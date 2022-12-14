using KinoPoisk.DomainLayer.Entities;
using KinoPoisk.DomainLayer.Intarfaces.Services;
using AutoMapper;
using KinoPoisk.DomainLayer.DTOs.GenreDTO;
using KinoPoisk.DomainLayer.Resources;
using KinoPoisk.DataAccessLayer;

namespace KinoPoisk.BusinessLogicLayer.Services.Implementations {
    public class GenreService : GenericService<Genre, GenreDTO, Guid> {
        public GenreService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper) {
        }

        protected override List<string> Validate(GenreDTO dto) {
            var errors = new List<string>();

            if (string.IsNullOrEmpty(dto.Name) || dto.Name.Length < Constants.MinLenOfName) {
                errors.Add(GenreResource.NameLessMinLen);
            }

            if (dto.Name.Length > Constants.MinLenOfName) {
                errors.Add(GenreResource.NameExceedsMaxLen);
            }

            return errors;
        }
    }
}
