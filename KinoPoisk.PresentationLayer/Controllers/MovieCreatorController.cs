using KinoPoisk.BusinessLogicLayer.Services.Implementations;
using KinoPoisk.DataAccessLayer;
using KinoPoisk.DomainLayer.DTOs.MovieCreatorDTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KinoPoisk.PresentationLayer.Controllers {
    [Authorize(Roles = Constants.NameRoleAdmin)]
    public class MovieCreatorController : CrudControllerBase<MovieCreatorService, MovieCreatorDTO, GetMovieCreatorDTO, Guid> {
        public MovieCreatorController(MovieCreatorService service) : base(service) {
        }
    }
}
