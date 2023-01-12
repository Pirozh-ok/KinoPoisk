using KinoPoisk.DomainLayer.DTOs.UserDTO;

namespace KinoPoisk.DomainLayer.Intarfaces.Services {
    public interface IUserService {
        Task<Result> LoginAsync(LoginDTO dto);
        Task<Result> RegisterAsync(UserDTO dto);
        Task<Result> ConfirmEmailAsync(string? userEmail);
        Task<Result> VerificationConfirmationTokenAsync(string token, string email);
        Task<Result> SendResetPasswordEmailAsync(string email);
        Task<Result> ResetPasswordAsync(ResetPasswordDTO resetPasswordData);
        Task<Result> UpdateUserData(UpdateUserDTO userDTO);
        Task<Result> ChangePassword(ChangePasswordDTO changePasswordData, string userId); 
    }
}