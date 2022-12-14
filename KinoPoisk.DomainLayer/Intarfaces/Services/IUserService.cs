using KinoPoisk.DomainLayer.DTOs.UserDTO;

namespace KinoPoisk.DomainLayer.Intarfaces.Services {
    public interface IUserService {
        Task<Result> LoginAsync(LoginDTO dto);
        Task<Result> RegisterAsync(UserDTO dto);
        Task<Result> ConfirmEmailAsync(string? userEmail);
        Task<Result> VerificationConfirmationToken(string token, string email);
    }
}