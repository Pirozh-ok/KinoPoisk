namespace KinoPoisk.DomainLayer.DTOs.Pageable.Base {
    public class PageableBaseResponseDto<TDto> {
        public int TotalItems { get; set; }
        public int FilteredItems {get; set; }
        public IEnumerable<TDto>? Items { get; set; }
    }
}
