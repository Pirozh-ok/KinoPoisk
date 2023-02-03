using KinoPoisk.BusinessLogicLayer.Services.Implementations;
using KinoPoisk.DataAccessLayer;
using KinoPoisk.DomainLayer.DTOs.MovieCreatorDTOs;
using KinoPoisk.DomainLayer.DTOs.MovieDTOs;
using KinoPoisk.DomainLayer.RequestParameterModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KinoPoisk.PresentationLayer.Controllers {
    [Authorize]
    public class MovieController : CrudControllerBase<MovieService, MovieDTO, GetMovieDTO, Guid> {

        private readonly RatingService _ratingService;

        public MovieController(MovieService service, RatingService ratingService) : base(service) {
            _ratingService = ratingService;
        }

        [HttpPost("rate-movie")]
        public async Task<IActionResult> RateMovie([FromBody] RatingDTO rating) {
            var result = await _ratingService.CreateOrUpdateRatingAsync(rating);
            return result.Success ? Ok(result) : BadRequest(result.Errors);
        }

        [HttpDelete("rate-movie")]
        public async Task<IActionResult> DeleteRatingMovie([FromQuery] Guid userId, [FromQuery] Guid movieId) {
            var result = await _ratingService.DeleteAsync(userId, movieId);
            return result.Success ? Ok(result) : BadRequest(result.Errors);
        }

        [HttpGet("rate-movie")]
        public async Task<IActionResult> GetRatingByIds([FromQuery] Guid userId, [FromQuery] Guid movieId) {
            var result = await _ratingService.GetByIdAsync<GetRatingDTO>(userId, movieId);
            return result.Success ? Ok(result) : BadRequest(result.Errors);
        }

        [Authorize(Roles = Constants.NameRoleAdmin)]
        [HttpGet("ratings")]
        public async Task<IActionResult> GetAllRating() {
            var result = await _ratingService.GetAllAsync<GetRatingDTO>();
            return result.Success ? Ok(result) : BadRequest(result.Errors);
        }

        [AllowAnonymous]
        [HttpGet("{movieId}/ratings")]
        public async Task<IActionResult> GetAllRatingByMovie(Guid movieId) {
            var result = await _ratingService.GetAllByMovieIdAsync<GetRatingDTO>(movieId);
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
        public async Task<IActionResult> GetMovieWithConstraint([FromQuery] MovieRequestParameters parameters) {
            return Ok(await _service.GetWithParameters(parameters));
        }
    }
}
