using KinoPoisk.DomainLayer.Entities;

namespace KinoPoisk.DomainLayer.DTOs.UserDTO {
    public class JwtGenerateDTO {
        public Guid UserId { get; set; }
        public string UserName {get; set;}
        public string Email { get; set; }
        public List<ApplicationRole> Roles { get; set;}
    }
}
