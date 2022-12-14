using KinoPoisk.DomainLayer.Intarfaces;

namespace KinoPoisk.DomainLayer.Entities {
    public class AgeCategory : IEntity<Guid> {
        public AgeCategory() {
            Movies = new HashSet<Movie>();
        }

        public Guid Id { get; set; } = Guid.Empty;
        public string Value { get; set; }
        public uint MinAge { get; set; }

        public virtual ICollection<Movie> Movies { get; set; }
    }
}
