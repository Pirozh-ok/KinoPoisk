using KinoPoisk.BusinessLogicLayer.Services.Implementations;
using KinoPoisk.DataAccessLayer;
using KinoPoisk.DomainLayer.DTOs.MovieCreatorDTOs;
using KinoPoisk.DomainLayer.Intarfaces.Services;
using Microsoft.AspNetCore.Authorization;

namespace KinoPoisk.PresentationLayer.Controllers {
    [Authorize(Roles = Constants.NameRoleAdmin)]
    public class CreatorController : CrudControllerBase<ICreatorService, CreatorDTO, GetCreatorDTO, Guid> {
        public CreatorController(ICreatorService service) : base(service) {
        }
    }
}
