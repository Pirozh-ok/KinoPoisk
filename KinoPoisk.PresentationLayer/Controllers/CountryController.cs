using KinoPoisk.BusinessLogicLayer.Services.Implementations;
using KinoPoisk.DomainLayer.DTOs.CountryDTO;

namespace KinoPoisk.PresentationLayer.Controllers {
    public class CountryController : CrudControllerBase<CountryService, CreateCountryDTO, UpdateCountryDTO, GetCountryDTO, Guid> {
        public CountryController(CountryService service) : base(service) {
        }
    }
}
