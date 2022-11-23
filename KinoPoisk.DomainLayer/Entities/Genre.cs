namespace KinoPoisk.DomainLayer.Entities
{
    public class Genre
    {
        public Genre()
        {
            Movies = new HashSet<Movie>(); 
        }

        public Guid Id { get; set; } = Guid.Empty; 
        public string Name { get; set; }

        public ICollection<Movie> Movies {get;set;}
    }
}
