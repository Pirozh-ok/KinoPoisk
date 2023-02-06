using KinoPoisk.DomainLayer.Entities.Base;

namespace KinoPoisk.DomainLayer.Entities {
    public class MovieRole : BaseEntity<Guid> {
        public MovieRole() {
            CreatorMovies = new HashSet<CreatorMovie>();
        }

        public string Name { get; set; }

        public virtual ICollection<CreatorMovie> CreatorMovies { get; set; }
    }
}
