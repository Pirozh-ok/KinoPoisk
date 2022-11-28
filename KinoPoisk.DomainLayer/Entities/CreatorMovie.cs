namespace KinoPoisk.DomainLayer.Entities {
    public class CreatorMovie {
        public CreatorMovie() {
            Roles = new HashSet<MovieRole>();
        }

        public Guid CreatorId { get; set; } = Guid.Empty;
        public Guid MovieId { get; set; } = Guid.Empty;

        public Creator Creator { get; set; }
        public Movie Movie { get; set; }
        public virtual ICollection<MovieRole> Roles { get; set; }
    }
}
