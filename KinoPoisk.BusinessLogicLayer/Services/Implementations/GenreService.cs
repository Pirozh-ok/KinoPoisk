using KinoPoisk.DomainLayer.Entities;
using KinoPoisk.DomainLayer.Intarfaces.Services;
using AutoMapper;
using KinoPoisk.DomainLayer.DTOs.GenreDTO;
using KinoPoisk.DomainLayer.Resources;
using KinoPoisk.DataAccessLayer;
using KinoPoisk.BusinessLogicLayer.Services.Base;
using KinoPoisk.DomainLayer;

namespace KinoPoisk.BusinessLogicLayer.Services.Implementations
{
    public class GenreService : BaseEntityService<Genre, Guid, GenreDTO>, IGenreService {
        public GenreService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper) {
        }

        protected override ServiceResult Validate(GenreDTO dto) {
            var errors = new List<string>();

            if (string.IsNullOrEmpty(dto.Name) || dto.Name.Length < Constants.MinLenOfName) {
                errors.Add(GenreResource.NameLessMinLen);
            }

            if (dto.Name.Length > Constants.MinLenOfName) {
                errors.Add(GenreResource.NameExceedsMaxLen);
            }

            return errors.Count() > 0 ? ServiceResult.Fail(errors) : ServiceResult.Ok();
        }
    }
}
