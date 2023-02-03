using KinoPoisk.DomainLayer.DTOs.Pageable.Base;

namespace KinoPoisk.DomainLayer.DTOs.Pageable {
    public class PageableMovieRequestDto : PageableBaseRequestDto {
        public string? Name { get; set; }
        public uint? Rating { get; set; }
    }
}
