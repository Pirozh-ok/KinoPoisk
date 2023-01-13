namespace KinoPoisk.DomainLayer.DTOs.AwardDTOs {
    public class GetAwardDTO {
        public Guid Id { get; set; } = Guid.Empty;
        public string Name { get; set; }
        public DateTime DateOfAward { get; set; }
        public Guid MovieId { get; set; }
    }
}
