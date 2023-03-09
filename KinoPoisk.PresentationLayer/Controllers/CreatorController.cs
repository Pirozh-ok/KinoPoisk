using KinoPoisk.DataAccessLayer;
using KinoPoisk.DomainLayer.DTOs.MovieCreatorDTOs;
using KinoPoisk.DomainLayer.DTOs.Pageable;
using KinoPoisk.DomainLayer.Intarfaces.Services;
using KinoPoisk.PresentationLayer.Controllers.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace KinoPoisk.PresentationLayer.Controllers {
    [Authorize(Roles = Constants.NameRoleAdmin)]
    public class CreatorController : CrudControllerBase<ICreatorService, CreatorDTO, GetCreatorDTO, Guid> {
        public CreatorController(ICreatorService service) : base(service) {
        }

        [AllowAnonymous]
        [HttpGet("search")]
        public async Task<IActionResult> GetFilteringCreators([FromQuery] PageableCreatorRequestDto filters) {
            var result = _service.SearchFor<GetCreatorDTO>(filters);
            return GetResult(result, (int)HttpStatusCode.OK);
        }
    }
}
