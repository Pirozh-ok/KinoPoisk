using KinoPoisk.DataAccessLayer;
using KinoPoisk.DomainLayer.DTOs.CountryDTO;
using KinoPoisk.DomainLayer.Intarfaces.Services;
using Microsoft.AspNetCore.Authorization;

namespace KinoPoisk.PresentationLayer.Controllers {
    [Authorize(Roles = Constants.NameRoleAdmin)]
    public class CountryController : CrudControllerBase<ICountryService, CountryDTO, GetCountryDTO, Guid> {
        public CountryController(ICountryService service) : base(service) {
        }
    }
}
