using KinoPoisk.DomainLayer.Entities;

namespace KinoPoisk.DomainLayer.DTOs.ContentDTOs {
    public class ContentDTO : BaseEntityDto<Guid> {
        public string Name { get; set; }
        public string Path { get; set; }
        public ContentType Type { get; set; }
        public Guid MovieId { get; set; }
    }
}
