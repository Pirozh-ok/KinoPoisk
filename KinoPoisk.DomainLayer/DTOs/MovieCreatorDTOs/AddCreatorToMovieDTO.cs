namespace KinoPoisk.DomainLayer.DTOs.MovieCreatorDTOs {
    public class AddCreatorToMovieDTO {
        public Guid CreatorId { get; set; }
        public Guid MovieId { get; set; }
        public IEnumerable<Guid> Roles { get; set; }
    }
}
