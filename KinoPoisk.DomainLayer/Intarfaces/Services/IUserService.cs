using KinoPoisk.DomainLayer.DTOs.Pageable;
using KinoPoisk.DomainLayer.DTOs.UserDTO;
using KinoPoisk.DomainLayer.Entities;

namespace KinoPoisk.DomainLayer.Intarfaces.Services {
    public interface IUserService : ISearchableEntityService<ApplicationUser, Guid, UserDTO, PageableUserRequestDto> {
        Task<ServiceResult> LoginAsync(LoginDTO dto);
        Task<ServiceResult> ConfirmEmailAsync();
        Task<ServiceResult> VerificationConfirmationTokenAsync(string token, string email);
        Task<ServiceResult> SendResetPasswordEmailAsync(string email);
        Task<ServiceResult> ResetPasswordAsync(ResetPasswordDTO resetPasswordData);
        Task<ServiceResult> ChangePasswordAsync(ChangePasswordDTO changePasswordData);
        Task<ServiceResult> ChangeEmailAsync(string newEmail);
    }
}