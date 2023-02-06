using KinoPoisk.DomainLayer.Entities.Base;

namespace KinoPoisk.DomainLayer.Entities {
    public class Genre : BaseEntity<Guid> {
        public Genre() {
            Movies = new HashSet<Movie>();
        }

        public string Name { get; set; }

        public virtual ICollection<Movie> Movies { get; set; }
    }
}
