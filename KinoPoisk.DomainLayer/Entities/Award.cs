using KinoPoisk.DomainLayer.Intarfaces;
using System.Security.Principal;

namespace KinoPoisk.DomainLayer.Entities {
    public class Award : IEntity<Guid> {
        public Guid Id { get; set; } = Guid.Empty;
        public string Name { get; set; }
        public DateTime DateOfAward { get; set; }
        public Guid MovieId { get; set; }

        public virtual Movie Movie { get; set; }
    }
}
