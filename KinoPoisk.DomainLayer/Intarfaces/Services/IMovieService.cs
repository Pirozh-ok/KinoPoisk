using KinoPoisk.DomainLayer.DTOs.MovieCreatorDTOs;
using KinoPoisk.DomainLayer.DTOs.MovieDTOs;
using KinoPoisk.DomainLayer.DTOs.Pageable;
using KinoPoisk.DomainLayer.Entities;

namespace KinoPoisk.DomainLayer.Intarfaces.Services {
    public interface IMovieService : ISearchableEntityService<Movie, Guid, MovieDTO, PageableMovieRequestDto> {
        Task<ServiceResult> AddOrUpdateCreatorToMovie(AddCreatorToMovieDTO dto);
        Task<ServiceResult> RemoveCreatorFromMovie(Guid movieId, Guid creatorId);
        Task<ServiceResult> GetCreaterByMovieAsync(Guid movieId);
        Task<ServiceResult> AddOrUpdateRatingToMovie(RatingDTO dto);
        Task<ServiceResult> RemoveRatingMovie(Guid userId, Guid movieId);
        ServiceResult GetFullRatingById<TGetDto>(Guid userId, Guid movieId);
        Task<ServiceResult> GetRatingsByMovieIdAsync<TGetDto>(Guid movieId);
    }
}
