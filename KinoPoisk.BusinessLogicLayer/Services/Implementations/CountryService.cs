using KinoPoisk.DomainLayer.Entities;
using KinoPoisk.DomainLayer.Intarfaces.Services;
using AutoMapper;
using KinoPoisk.DomainLayer.DTOs.CountryDTO;
using KinoPoisk.DomainLayer.Resources;
using KinoPoisk.BusinessLogicLayer.Services.Base;

namespace KinoPoisk.BusinessLogicLayer.Services.Implementations
{
    public class CountryService : BaseService<Country, CountryDTO, Guid> {
        public CountryService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper) {
        }

        protected override List<string> Validate(CountryDTO dto) {
            var errors = new List<string>();

            if (string.IsNullOrEmpty(dto.Name) || dto.Name.Length < 3) {
                errors.Add(CountryResource.NameLessMinLen);
            }

            if (dto.Name.Length > 50) {
                errors.Add(CountryResource.NameExceedsMaxLen);
            }

            return errors;
        }
    }
}