using KinoPoisk.DataAccessLayer;
using KinoPoisk.DomainLayer.DTOs.MovieCreatorDTOs;
using KinoPoisk.DomainLayer.DTOs.MovieDTOs;
using KinoPoisk.DomainLayer.DTOs.Pageable;
using KinoPoisk.DomainLayer.Intarfaces.Services;
using KinoPoisk.PresentationLayer.Controllers.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace KinoPoisk.PresentationLayer.Controllers {
    [Authorize]
    public class MovieController : CrudControllerBase<IMovieService, MovieDTO, GetMovieDTO, Guid> {

        public MovieController(IMovieService service) : base(service) {
        }

        [HttpPost("rate-movie")]
        public async Task<IActionResult> RateMovie([FromBody] RatingDTO rating) {
            var result = await _service.AddOrUpdateRatingToMovie(rating);
            return GetResult(result, (int)HttpStatusCode.Created);
        }

        [HttpDelete("rate-movie")]
        public async Task<IActionResult> DeleteRatingMovie([FromQuery] Guid userId, [FromQuery] Guid movieId) {
            var result = await _service.RemoveRatingMovie(userId, movieId);
            return GetResult(result, (int)HttpStatusCode.NoContent);
        }

        [HttpGet("rate-movie")]
        public async Task<IActionResult> GetRatingByIds([FromQuery] Guid userId, [FromQuery] Guid movieId) {
            var result = _service.GetFullRatingById<GetRatingDTO>(userId, movieId);
            return GetResult(result, (int)HttpStatusCode.OK);
        }

        [Authorize]
        [HttpGet("{movieId}/ratings")]
        public async Task<IActionResult> GetAllRatingByMovie([FromQuery]PageableRatingRequestDto parameters, Guid movieId) {
            parameters.MovieId= movieId;
            var result = await _service.GetRatingsByMovieIdAsync(parameters);
            return GetResult(result, (int)HttpStatusCode.OK);
        }

        [Authorize(Roles = Constants.NameRoleAdmin)]
        [HttpPost("add-creator")]
        public async Task<IActionResult> AddCreatorToFilm([FromBody] AddCreatorToMovieDTO dto) {
            var result = await _service.AddOrUpdateCreatorToMovie(dto);
            return GetResult(result, (int)HttpStatusCode.NoContent);
        }

        [Authorize(Roles = Constants.NameRoleAdmin)]
        [HttpDelete("remove-creator")]
        public async Task<IActionResult> RemoveCreatorFromFilm([FromQuery] Guid movieId, [FromQuery] Guid creatorId) {
            var result = await _service.RemoveCreatorFromMovie(movieId, creatorId);
            return GetResult(result, (int)HttpStatusCode.NoContent);
        }

        [HttpGet("{movieId}/creators")]
        public async Task<IActionResult> GetCreatorsByMovie(Guid movieId) {
            var result = await _service.GetCreaterByMovieAsync(movieId);
            return GetResult(result, (int)HttpStatusCode.OK);
        }

        [AllowAnonymous]
        [HttpGet("search")]
        public async Task<IActionResult> GetMovieWithConstraint([FromQuery] PageableMovieRequestDto filters) {
            var result = _service.SearchFor<GetMovieForDashBoardDto>(filters);
            return GetResult(result, (int)HttpStatusCode.OK);
        }

        //[AllowAnonymous]
        //[HttpGet("dashboard")]
        //public async Task<IActionResult> GetMoviesForDashBoard() {
        //    var result = await _service.GetAsync<GetMovieForDashBoardDto>();
        //    return GetResult(result, (int)HttpStatusCode.OK);
        //}
    }
}
