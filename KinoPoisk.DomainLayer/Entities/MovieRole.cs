namespace KinoPoisk.DomainLayer.Entities
{
    public class MovieRole
    {
        public MovieRole()
        { 
            Creator_Movies = new HashSet<Creator_Movie>();
        }

        public Guid Id { get; set; } = Guid.Empty;
        public string Name { get; set; }

        public ICollection<Creator_Movie> Creator_Movies { get; set; }
    }
}
