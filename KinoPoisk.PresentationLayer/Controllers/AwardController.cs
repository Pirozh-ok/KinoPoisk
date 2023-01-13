using KinoPoisk.BusinessLogicLayer.Services.Implementations;
using KinoPoisk.DataAccessLayer;
using KinoPoisk.DomainLayer.DTOs.AwardDTOs;
using Microsoft.AspNetCore.Authorization;

namespace KinoPoisk.PresentationLayer.Controllers {
    [Authorize(Roles=Constants.NameRoleAdmin)]
    public class AwardController : CrudControllerBase<AwardService, AwardDTO, GetAwardDTO, Guid> {
        public AwardController(AwardService service) : base(service) {
        }
    }
}
