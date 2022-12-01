using KinoPoisk.DomainLayer.DTOs.UserDTO;

namespace KinoPoisk.DomainLayer.Intarfaces.Services {
    public interface IUserService {
        Task<Result> LoginAsync(LoginDTO dto);
        Task<Result> LogoutAsync();
        Task<Result> RegisterAsync(CreateUserDTO dto); 
    }
}