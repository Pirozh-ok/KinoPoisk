namespace KinoPoisk.DomainLayer.Entities
{
    public class Creator
    {
        public Creator() 
        {
            Movies = new HashSet<Creator_Movie>();
        }

        public Guid Id { get; set; } = Guid.Empty;
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Patronymic { get; set; }
        public DateTime DateOfBirth { get; set; }

        public ICollection<Creator_Movie> Movies { get; set; } 
    }
}
