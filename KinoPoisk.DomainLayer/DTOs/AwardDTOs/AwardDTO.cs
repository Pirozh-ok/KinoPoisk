namespace KinoPoisk.DomainLayer.DTOs.AwardDTOs {
    public class AwardDTO : BaseEntityDto<Guid> {
        public string Name { get; set; }
        public DateTime DateOfAward { get; set; }
        public Guid MovieId { get; set; }
    }
}
