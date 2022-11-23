namespace KinoPoisk.DomainLayer.Entities
{
    public class UserRole
    {
        public UserRole() 
        {
            Users = new HashSet<User>();
        }

        public Guid Id { get; set; } = Guid.Empty;
        public string Name { get; set; }

        public ICollection<User> Users { get; set; }
    }
}
