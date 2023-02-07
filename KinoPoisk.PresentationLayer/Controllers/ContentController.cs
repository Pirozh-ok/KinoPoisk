using KinoPoisk.BusinessLogicLayer.Services.Implementations;
using KinoPoisk.DataAccessLayer;
using KinoPoisk.DomainLayer.DTOs.ContentDTOs;
using KinoPoisk.DomainLayer.Intarfaces.Services;
using Microsoft.AspNetCore.Authorization;

namespace KinoPoisk.PresentationLayer.Controllers {
    [Authorize(Roles = Constants.NameRoleAdmin)]
    public class ContentController : CrudControllerBase<IContentService, ContentDTO, GetContentDTO, Guid> {
        public ContentController(IContentService service) : base(service) {
        }
    }
}
