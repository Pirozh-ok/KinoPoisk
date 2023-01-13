using KinoPoisk.BusinessLogicLayer.Services.Implementations;
using KinoPoisk.DataAccessLayer;
using KinoPoisk.DomainLayer.DTOs.CountryDTO;
using Microsoft.AspNetCore.Authorization;

namespace KinoPoisk.PresentationLayer.Controllers {
    [Authorize(Roles = Constants.NameRoleAdmin)]
    public class CountryController : CrudControllerBase<CountryService, CountryDTO, GetCountryDTO, Guid> {
        public CountryController(CountryService service) : base(service) {
        }
    }
}
