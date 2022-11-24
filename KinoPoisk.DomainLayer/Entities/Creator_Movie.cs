namespace KinoPoisk.DomainLayer.Entities
{
    public class Creator_Movie
    {
        public Creator_Movie()
        {
            Roles = new HashSet<MovieRole>(); 
        }

        public Guid CreatorId { get; set; } = Guid.Empty; 
        public Creator Creator { get; set; }

        public Guid MovieId { get; set; } = Guid.Empty;
        public Movie Movie { get; set; }

        public ICollection<MovieRole> Roles { get; set; }
    }
}
