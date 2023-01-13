namespace KinoPoisk.DomainLayer.DTOs.MovieCreatorDTOs {
    public class GetMovieCreatorDTO {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Patronymic { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
