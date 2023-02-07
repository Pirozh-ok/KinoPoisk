using KinoPoisk.DataAccessLayer;
using KinoPoisk.DomainLayer.DTOs.AgeCategoryDTO;
using KinoPoisk.DomainLayer.Intarfaces.Services;
using KinoPoisk.PresentationLayer.Controllers.Base;
using Microsoft.AspNetCore.Authorization;

namespace KinoPoisk.PresentationLayer.Controllers
{
    [Authorize(Roles = Constants.NameRoleAdmin)]
    public class AgeCategoryController : CrudControllerBase<IAgeCategoryService, AgeCategoryDTO, GetAgeCategoryDTO, Guid> {
        public AgeCategoryController(IAgeCategoryService service) : base(service) {
        }
    }
}
