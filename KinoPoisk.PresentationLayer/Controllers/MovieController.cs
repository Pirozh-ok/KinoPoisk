using KinoPoisk.BusinessLogicLayer.Services.Implementations;
using KinoPoisk.DataAccessLayer;
using KinoPoisk.DomainLayer.DTOs.MovieDTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KinoPoisk.PresentationLayer.Controllers {
    //[Authorize(Roles = Constants.NameRoleAdmin)]
    public class MovieController : CrudControllerBase<MovieService, MovieDTO, GetMovieDTO, Guid> {
        public MovieController(MovieService service) : base(service) {
        }

        [HttpPost("rate-movie")]
        public async Task<IActionResult> RateMovie([FromBody] RatingDTO rating) {
            
            return Ok(); 
        }
    }
}
