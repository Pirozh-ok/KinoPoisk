using KinoPoisk.DomainLayer.DTOs.Pageable.Base;

namespace KinoPoisk.DomainLayer.DTOs.Pageable {
    public class PageableUserRequestDto : PageableBaseRequestDto {
        public string? Country { get; set; }
        public int? AgeFrom { get; set; }
        public int? AgeTo { get; set; }
    }
}
