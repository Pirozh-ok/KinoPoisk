namespace KinoPoisk.DomainLayer.Entities
{
    public class Country
    {
        public Country()
        { 
            Movies = new HashSet<Movie>();
        }

        public uint Id { get; set; }
        public string Name { get; set; }

        public ICollection<Movie> Movies { get; set; }
    }
}
