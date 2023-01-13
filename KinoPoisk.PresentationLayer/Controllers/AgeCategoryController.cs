using KinoPoisk.BusinessLogicLayer.Services.Implementations;
using KinoPoisk.DomainLayer.DTOs.AgeCategoryDTO;

namespace KinoPoisk.PresentationLayer.Controllers {
    public class AgeCategoryController : CrudControllerBase<AgeCategoryService, AgeCategoryDTO, GetAgeCategoryDTO, Guid> {
        public AgeCategoryController(AgeCategoryService service) : base(service) {
        }
    }
}
