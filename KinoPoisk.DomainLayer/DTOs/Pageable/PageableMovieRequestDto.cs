using KinoPoisk.DomainLayer.DTOs.Pageable.Base;

namespace KinoPoisk.DomainLayer.DTOs.Pageable {
    public class PageableMovieRequestDto : PageableBaseRequestDto {
        public double? RatingFrom { get; set; }
        public double? RatingTo { get; set; }
        public decimal? WorldFeesFrom { get; set; }
        public decimal? WorldFeesTo { get; set; }
        public string? Genre { get; set; }
        public int? AgeTo { get; set; }
        public int? DateYearFrom { get; set; }
        public int? DateYearTo { get; set; }
        public string? Country { get; set; }
        public int? DurationFrom { get; set; }
        public int? DurationTo { get; set; }
    }
}
