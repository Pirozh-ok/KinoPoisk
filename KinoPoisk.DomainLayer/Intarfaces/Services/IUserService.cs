using KinoPoisk.DomainLayer.DTOs.UserDTO;

namespace KinoPoisk.DomainLayer.Intarfaces.Services {
    public interface IUserService {
        Task<Result> LoginAsync(LoginDTO dto);
        Task<Result> RegisterAsync(UserDTO dto);
        Task<Result> ConfirmEmailAsync(string? userId);
        Task<Result> VerificationConfirmationTokenAsync(string token, string email);
        Task<Result> SendResetPasswordEmailAsync(string email);
        Task<Result> ResetPasswordAsync(ResetPasswordDTO resetPasswordData);
        Task<Result> UpdateUserDataAsync(UpdateUserDTO userDTO);
        Task<Result> ChangePasswordAsync(ChangePasswordDTO changePasswordData, string userId);
        Task<Result> ChangeEmailAsync(string userId, string newEmail); 
    }
}