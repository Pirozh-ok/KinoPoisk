namespace KinoPoisk.DomainLayer.Entities
{
    public class Rating
    {
        public Guid MovieId { get; set; }
        public Guid UserId { get; set; }
        public uint MovieRating { get; set; }
        public string Comment { get; set; }
    }
}
