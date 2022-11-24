namespace KinoPoisk.DomainLayer.Entities
{
    public class Country
    {
        public Country()
        { 
            Movies = new HashSet<Movie>();
            Users = new HashSet<User>();
        }

        public Guid Id { get; set; } = Guid.Empty;
        public string Name { get; set; }

        public ICollection<Movie> Movies { get; set; }
        public ICollection<User> Users { get; set; }
    }
}
