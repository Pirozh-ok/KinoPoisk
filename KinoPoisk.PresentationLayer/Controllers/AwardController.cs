using KinoPoisk.DataAccessLayer;
using KinoPoisk.DomainLayer.DTOs.AwardDTOs;
using KinoPoisk.DomainLayer.Intarfaces.Services;
using Microsoft.AspNetCore.Authorization;

namespace KinoPoisk.PresentationLayer.Controllers {
    [Authorize(Roles=Constants.NameRoleAdmin)]
    public class AwardController : CrudControllerBase<IAwardService, AwardDTO, GetAwardDTO, Guid> {
        public AwardController(IAwardService service) : base(service) {
        }
    }
}
