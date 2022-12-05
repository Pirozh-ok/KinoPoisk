using KinoPoisk.DomainLayer.Entities;

namespace KinoPoisk.DomainLayer.DTOs.UserDTO {
    public class GetUserDTO {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Patronymic { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime DateOfRegistration { get; set; }
        public Guid CountryId{ get; set; }
    }
}
