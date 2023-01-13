using KinoPoisk.BusinessLogicLayer.Services.Implementations;
using KinoPoisk.DataAccessLayer;
using KinoPoisk.DomainLayer.DTOs.GenreDTO;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace KinoPoisk.PresentationLayer.Controllers {
    [Authorize(Roles = Constants.NameRoleAdmin)]
    public class GenreController : CrudControllerBase<GenreService,GenreDTO, GetGenreDTO, Guid> {
        public GenreController(GenreService service) : base(service) {
        }
    }
}
