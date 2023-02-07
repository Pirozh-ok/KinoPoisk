using KinoPoisk.BusinessLogicLayer.Services.Implementations;
using KinoPoisk.DataAccessLayer;
using KinoPoisk.DomainLayer.DTOs.MovieCreatorDTOs;
using KinoPoisk.DomainLayer.DTOs.MovieDTOs;
using KinoPoisk.DomainLayer.DTOs.Pageable;
using KinoPoisk.DomainLayer.Intarfaces.Services;
using KinoPoisk.PresentationLayer.Controllers.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KinoPoisk.PresentationLayer.Controllers
{
    [Authorize]
    public class MovieController : CrudControllerBase<IMovieService, MovieDTO, GetMovieDTO, Guid> {

        public MovieController(IMovieService service) : base(service) {
        }

        [HttpPost("rate-movie")]
        public async Task<IActionResult> RateMovie([FromBody] RatingDTO rating) {
            var result = await _service.AddOrUpdateRatingToMovie(rating);
            return result.Success ? Ok(result) : BadRequest(result.Errors);
        }

        [HttpDelete("rate-movie")]
        public async Task<IActionResult> DeleteRatingMovie([FromQuery] Guid userId, [FromQuery] Guid movieId) {
            var result = await _service.RemoveRatingMovie(userId, movieId);
            return result.Success ? Ok(result) : BadRequest(result.Errors);
        }

        [HttpGet("rate-movie")]
        public async Task<IActionResult> GetRatingByIds([FromQuery] Guid userId, [FromQuery] Guid movieId) {
            var result = _service.GetFullRatingById<GetRatingDTO>(userId, movieId);
            return result.Success ? Ok(result) : BadRequest(result.Errors);
        }

        [AllowAnonymous]
        [HttpGet("{movieId}/ratings")]
        public async Task<IActionResult> GetAllRatingByMovie(Guid movieId) {
            var result = await _service.GetRatingsByMovieIdAsync<GetRatingDTO>(movieId);
            return result.Success ? Ok(result) : BadRequest(result.Errors);
        }

        [Authorize(Roles = Constants.NameRoleAdmin)]
        [HttpPost("add-creator")]
        public async Task<IActionResult> AddCreatorToFilm([FromBody] AddCreatorToMovieDTO dto) {
            var result = await _service.AddOrUpdateCreatorToMovie(dto);
            return result.Success ? Ok(result) : BadRequest(result.Errors);
        }

        [Authorize(Roles = Constants.NameRoleAdmin)]
        [HttpDelete("remove-creator")]
        public async Task<IActionResult> RemoveCreatorFromFilm([FromQuery] Guid movieId, [FromQuery] Guid creatorId) {
            var result = await _service.RemoveCreatorFromMovie(movieId, creatorId);
            return result.Success ? Ok(result) : BadRequest(result.Errors);
        }

        [HttpGet("{movieId}/creators")]
        public async Task<IActionResult> GetCreatorsByMovie(Guid movieId) {
            var result = await _service.GetCreaterByMovieAsync(movieId);
            return result.Success ? Ok(result) : BadRequest(result.Errors);
        }

        [AllowAnonymous]
        [HttpGet("filtering")]
        public async Task<IActionResult> GetMovieWithConstraint([FromQuery] PageableMovieRequestDto filters) {
            var result = _service.SearchFor<GetMovieDTO>(filters);
            return result.Success ? Ok(result) : BadRequest(result.Errors);
        }
    }
}
