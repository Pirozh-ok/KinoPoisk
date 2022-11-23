namespace KinoPoisk.DomainLayer.Entities
{
    public class Creator_Movie
    {
        public Creator_Movie()
        {
            Roles = new HashSet<MovieRole>(); 
        }

        public uint CreatorId { get; set; }
        public uint MovieId { get; set; }
        public ICollection<MovieRole> Roles { get; set; }
    }
}
