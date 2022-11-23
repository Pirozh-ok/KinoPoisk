namespace KinoPoisk.DomainLayer.Entities
{
    public class User
    {
        public User()
        {
            MovieRatings = new HashSet<Rating>(); 
        }

        public Guid Id { get; set; } = Guid.Empty;
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? Patronymic { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }

        public Guid RoleId { get; set; }
        public UserRole Role { get; set; }

        public ICollection<Rating> MovieRatings { get; set; }

        public Guid CountryId { get; set; }
        public Country Country { get; set; }
    }
}