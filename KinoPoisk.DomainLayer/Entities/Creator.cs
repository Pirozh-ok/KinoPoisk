using KinoPoisk.DomainLayer.Interfaces;

namespace KinoPoisk.DomainLayer.Entities
{
    public class Creator : IEntity{
        public Creator() {
            CreatorsMovies = new HashSet<CreatorMovie>();
        }

        public Guid Id { get; set; } = Guid.Empty;
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Patronymic { get; set; }
        public DateTime DateOfBirth { get; set; }

        public virtual ICollection<CreatorMovie> CreatorsMovies { get; set; }
    }
}
