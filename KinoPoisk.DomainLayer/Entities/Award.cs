using KinoPoisk.DomainLayer.Entities.Base;

namespace KinoPoisk.DomainLayer.Entities {
    public class Award : BaseEntity<Guid> {
        public string Name { get; set; }
        public DateTime DateOfAward { get; set; }
        public Guid MovieId { get; set; }

        public virtual Movie Movie { get; set; }
    }
}
