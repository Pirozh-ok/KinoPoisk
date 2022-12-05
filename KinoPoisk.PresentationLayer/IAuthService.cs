using KinoPoisk.DomainLayer.DTOs.UserDTO;

namespace KinoPoisk.PresentationLayer {
    public interface IAuthService {
        string GenerateToken(JwtGenerateDTO userData); 
    }
}
