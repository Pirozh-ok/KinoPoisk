namespace KinoPoisk.DomainLayer.DTOs.UserDTO {
    public class LoginDTO {
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsPersistent { get; set; } = true; 
    }
}
