using KinoPoisk.DomainLayer.DTOs.UserDTO;
using Microsoft.AspNetCore.Mvc;

namespace KinoPoisk.DomainLayer.Intarfaces.Services {
    public interface IUserService {
        Task<Result> LoginAsync(LoginDTO dto);
        Task<Result> RegisterAsync(CreateUserDTO dto, IUrlHelper url, string scheme);
        Task ConfirmEmailAsync(string userEmail, IUrlHelper url, string scheme);
        Task<Result> VerificationConfirmationToken(string token, string email);
    }
}