using KinoPoisk.DomainLayer.DTOs.UserDTO;
using System.Security.Claims;

namespace KinoPoisk.PresentationLayer {
    public interface IAuthService {
        string GenerateToken(List<Claim> claims); 
    }
}
