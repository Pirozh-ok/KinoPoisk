using KinoPoisk.DomainLayer.DTOs.UserDTO;
using System.Security.Claims;

namespace KinoPoisk.PresentationLayer {
    public interface ITokenService {
        string GenerateToken(List<Claim> claims); 
    }
}
