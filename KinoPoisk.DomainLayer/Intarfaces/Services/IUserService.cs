using KinoPoisk.DomainLayer.DTOs.UserDTO;

namespace KinoPoisk.DomainLayer.Intarfaces.Services {
    public interface IUserService {
        Task<Result> LoginAsync(LoginDTO dto);
        Task<Result> RegisterAsync(UserDTO dto);
        Task<Result> ConfirmEmailAsync();
        Task<Result> VerificationConfirmationTokenAsync(string token, string email);
        Task<Result> SendResetPasswordEmailAsync(string email);
        Task<Result> ResetPasswordAsync(ResetPasswordDTO resetPasswordData);
        Task<Result> UpdateUserDataAsync(UpdateUserDTO userDTO);
        Task<Result> ChangePasswordAsync(ChangePasswordDTO changePasswordData);
        Task<Result> ChangeEmailAsync(string newEmail);
        Task<Result> DeleteUserAsync(Guid userId);
        Task<Result> GetAllUsersAsync();
        Task<Result> GetUserById(Guid id);
    }
}