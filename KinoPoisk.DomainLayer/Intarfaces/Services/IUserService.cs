using KinoPoisk.DomainLayer.DTOs.UserDTO;
using Microsoft.AspNetCore.Mvc;

namespace KinoPoisk.DomainLayer.Intarfaces.Services {
    public interface IUserService {
        Task<Result> LoginAsync(LoginDTO dto);
        Task<Result> RegisterAsync(CreateUserDTO dto);
        Task ConfirmEmailAsync(string userEmail);
        Task<Result> VerificationConfirmationToken(string token, string email);
    }
}