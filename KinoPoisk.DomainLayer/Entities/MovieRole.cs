namespace KinoPoisk.DomainLayer.Entities {
    public class MovieRole {
        public MovieRole() {
            CreatorMovies = new HashSet<CreatorMovie>();
        }

        public Guid Id { get; set; } = Guid.Empty;
        public string Name { get; set; }

        public virtual ICollection<CreatorMovie> CreatorMovies { get; set; }
    }
}
