namespace KinoPoisk.DomainLayer.Entities
{
    public class Award
    {
        public Guid Id { get; set; } = Guid.Empty;
        public string Name { get; set; }
        public DateTime DateOfAward { get; set; }

        public Guid MovieId { get; set; }
        public Movie Movie { get; set; }
    }
}
