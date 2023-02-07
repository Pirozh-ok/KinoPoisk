using KinoPoisk.DataAccessLayer;
using KinoPoisk.DomainLayer.DTOs.MovieRoleDTOs;
using KinoPoisk.DomainLayer.Intarfaces.Services;
using Microsoft.AspNetCore.Authorization;

namespace KinoPoisk.PresentationLayer.Controllers {
    [Authorize(Roles = Constants.NameRoleAdmin)]
    public class MovieRoleController : CrudControllerBase<IMovieRoleService, MovieRoleDTO, GetMovieRoleDTO, Guid> {
        public MovieRoleController(IMovieRoleService service) : base(service) {
        }
    }
}
