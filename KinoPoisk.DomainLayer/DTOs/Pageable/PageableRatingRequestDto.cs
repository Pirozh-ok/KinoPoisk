namespace KinoPoisk.DomainLayer.DTOs.Pageable {
    public class PageableRatingRequestDto {
        public uint Skip { get; set; } = 0;
        public uint Take { get; set; } = 2;
        public Guid? MovieId { get; set; }
    }
}
