using KinoPoisk.DomainLayer.DTOs.MovieDTOs;
using KinoPoisk.DomainLayer.DTOs.UserDTO;

namespace KinoPoisk.DomainLayer.Intarfaces.Services {
    public interface IUserService {
        Task<ServiceResult> LoginAsync(LoginDTO dto);
        Task<ServiceResult> RegisterAsync(UserDTO dto);
        Task<ServiceResult> ConfirmEmailAsync();
        Task<ServiceResult> VerificationConfirmationTokenAsync(string token, string email);
        Task<ServiceResult> SendResetPasswordEmailAsync(string email);
        Task<ServiceResult> ResetPasswordAsync(ResetPasswordDTO resetPasswordData);
        Task<ServiceResult> UpdateUserDataAsync(UpdateUserDTO userDTO);
        Task<ServiceResult> ChangePasswordAsync(ChangePasswordDTO changePasswordData);
        Task<ServiceResult> ChangeEmailAsync(string newEmail);
        Task<ServiceResult> DeleteUserAsync(Guid userId);
        Task<ServiceResult> GetAllUsersAsync();
        Task<ServiceResult> GetUserById(Guid id);
    }
}