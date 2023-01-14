namespace KinoPoisk.DomainLayer.DTOs.MovieDTOs {
    public class RatingDTO {
        public Guid MovieId { get; set; }
        public string Comment { get; set; }
        public uint MovieRating { get; set; }
    }
}
