using KinoPoisk.DomainLayer.Entities.Base;

namespace KinoPoisk.DomainLayer.Entities {
    public class Creator : BaseEntity<Guid> {
        public Creator() {
            CreatorsMovies = new HashSet<CreatorMovie>();
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Patronymic { get; set; }
        public DateTime DateOfBirth { get; set; }

        public virtual ICollection<CreatorMovie> CreatorsMovies { get; set; }
    }
}
