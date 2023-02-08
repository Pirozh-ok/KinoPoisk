using KinoPoisk.DomainLayer.DTOs.Pageable.Base;

namespace KinoPoisk.DomainLayer.DTOs.Pageable {
    public class PageableCreatorRequestDto : PageableBaseRequestDto{
        public int? AgeFrom { get; set; }
        public int? AgeTo { get; set; }
        public int? CountMovieFrom { get; set; }
        public int? CountMovieTo { get; set; }
    }
}
