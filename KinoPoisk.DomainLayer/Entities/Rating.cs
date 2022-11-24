namespace KinoPoisk.DomainLayer.Entities
{
    public class Rating
    {
        public uint MovieRating { get; set; }
        public string Comment { get; set; }

        public Guid MovieId { get; set; }
        public Movie Movie { get; set; }

        public Guid UserId { get; set; }
        public User User { get; set; }
        
    }
}
