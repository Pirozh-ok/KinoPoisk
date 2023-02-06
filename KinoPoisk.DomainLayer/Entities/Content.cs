using KinoPoisk.DomainLayer.Entities.Base;

namespace KinoPoisk.DomainLayer.Entities {
    public enum ContentType {
        Poster,
        Trailer,
        Movie
    }

    public class Content : BaseEntity<Guid> {
        public Guid Id { get; set; } = Guid.Empty;
        public string Name { get; set; }
        public string Path { get; set; }
        public ContentType Type { get; set; }
        public Guid MovieId { get; set; }

        public Movie Movie { get; set; }
    }
}
