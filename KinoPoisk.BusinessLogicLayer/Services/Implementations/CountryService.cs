using KinoPoisk.DomainLayer.Entities;
using KinoPoisk.DomainLayer.Intarfaces.Services;
using AutoMapper;

namespace KinoPoisk.BusinessLogicLayer.Services.Implementations {
    public class CountryService : GenericService<Country, Guid> {
        public CountryService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper) {
        }
    }
}