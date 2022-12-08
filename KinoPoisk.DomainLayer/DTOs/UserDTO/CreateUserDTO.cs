namespace KinoPoisk.DomainLayer.DTOs.UserDTO {
    public class CreateUserDTO {
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? Patronymic { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Guid? CountryId { get; set; }
    }
}
