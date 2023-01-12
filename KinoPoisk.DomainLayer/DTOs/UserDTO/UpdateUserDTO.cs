namespace KinoPoisk.DomainLayer.DTOs.UserDTO {
    public class UpdateUserDTO {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? Patronymic { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public Guid? CountryId { get; set; }
    }
}
