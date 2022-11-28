using KinoPoisk.DomainLayer.Interfaces;

namespace KinoPoisk.DomainLayer.Entities
{
    public class Country : IEntity {
        public Country() {
            Movies = new HashSet<Movie>();
            Users = new HashSet<ApplicationUser>();
        }

        public Guid Id { get; set; } = Guid.Empty;
        public string Name { get; set; }

        public virtual ICollection<Movie> Movies { get; set; }
        public virtual ICollection<ApplicationUser> Users { get; set; }
    }
}
