namespace KinoPoisk.DomainLayer.DTOs.MovieDTOs {
    public class AboutMovieRatingsDTO {
        public GetRatingDTO? UserRating { get; set; }
        public IEnumerable<GetRatingDTO?> Ratings { get; set; }
    }
}
