using KinoPoisk.BusinessLogicLayer.Services.Implementations;
using KinoPoisk.DataAccessLayer;
using KinoPoisk.DomainLayer.DTOs.MovieRoleDTOs;
using Microsoft.AspNetCore.Authorization;

namespace KinoPoisk.PresentationLayer.Controllers {
    [Authorize(Roles = Constants.NameRoleAdmin)]
    public class MovieRoleController : CrudControllerBase<MovieRoleService, MovieRoleDTO, GetMovieRoleDTO, Guid> {
        public MovieRoleController(MovieRoleService service) : base(service) {
        }
    }
}
