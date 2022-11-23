namespace KinoPoisk.DomainLayer.Entities
{
    public class AgeCategory
    {
        public AgeCategory()
        {
            Movies = new HashSet<Movie>();
        }

        public Guid Id { get; set; } = Guid.Empty; 
        public string Value { get; set; }
        public ICollection<Movie> Movies { get; set; }
    }
}
