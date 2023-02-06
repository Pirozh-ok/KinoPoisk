using KinoPoisk.DomainLayer.Entities.Base;

namespace KinoPoisk.DomainLayer.Entities {
    public class AgeCategory : BaseEntity<Guid> {
        public AgeCategory() {
            Movies = new HashSet<Movie>();
        }

        public string Value { get; set; }
        public uint MinAge { get; set; }

        public virtual ICollection<Movie> Movies { get; set; }
    }
}
