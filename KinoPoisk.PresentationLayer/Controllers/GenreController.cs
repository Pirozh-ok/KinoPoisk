using KinoPoisk.DataAccessLayer;
using KinoPoisk.DomainLayer.DTOs.GenreDTO;
using KinoPoisk.DomainLayer.Intarfaces.Services;
using KinoPoisk.PresentationLayer.Controllers.Base;
using Microsoft.AspNetCore.Authorization;

namespace KinoPoisk.PresentationLayer.Controllers
{
    [Authorize(Roles = Constants.NameRoleAdmin)]
    public class GenreController : CrudControllerBase<IGenreService,GenreDTO, GetGenreDTO, Guid> {
        public GenreController(IGenreService service) : base(service) {
        }
    }
}
