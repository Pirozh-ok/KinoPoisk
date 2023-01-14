using KinoPoisk.BusinessLogicLayer.Services.Implementations;
using KinoPoisk.DataAccessLayer;
using KinoPoisk.DomainLayer.DTOs.MovieDTOs;
using Microsoft.AspNetCore.Authorization;

namespace KinoPoisk.PresentationLayer.Controllers {
    //[Authorize(Roles = Constants.NameRoleAdmin)]
    public class MovieController : CrudControllerBase<MovieService, MovieDTO, GetMovieDTO, Guid> {
        public MovieController(MovieService service) : base(service) {
        }
    }
}
