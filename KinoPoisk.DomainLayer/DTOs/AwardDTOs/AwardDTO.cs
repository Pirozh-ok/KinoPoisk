namespace KinoPoisk.DomainLayer.DTOs.AwardDTOs {
    public class AwardDTO {
        public Guid? Id { get; set; }
        public string Name { get; set; }
        public DateTime DateOfAward { get; set; }
        public Guid MovieId { get; set; }
    }
}
