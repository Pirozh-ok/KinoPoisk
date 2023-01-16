using KinoPoisk.BusinessLogicLayer.Services.Implementations;
using KinoPoisk.DomainLayer.DTOs.MovieDTOs;
using KinoPoisk.DomainLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Bcpg;

namespace KinoPoisk.PresentationLayer.Controllers {
    //[Authorize(Roles = Constants.NameRoleAdmin)]
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

        [HttpGet("ratings")]
        public async Task<IActionResult> GetAllRating() {
            var result = await _ratingService.GetAllAsync<GetRatingDTO>();
            return result.Success ? Ok(result) : BadRequest(result.Errors);
        }

        [HttpGet("{movieId}/ratings")]
        public async Task<IActionResult> GetAllRating(Guid movieId) {
            var result = await _ratingService.GetAllByMovieIdAsync<GetRatingDTO>(movieId);
            return result.Success ? Ok(result) : BadRequest(result.Errors);
        }
    }
}
