using KinoPoisk.DomainLayer.Entities.Base;

namespace KinoPoisk.DomainLayer.Entities {
    public class Country : BaseEntity<Guid> {
        public Country() {
            Movies = new HashSet<Movie>();
            Users = new HashSet<ApplicationUser>();
        }

        public string Name { get; set; }

        public virtual ICollection<Movie> Movies { get; set; }
        public virtual ICollection<ApplicationUser> Users { get; set; }
    }
}
