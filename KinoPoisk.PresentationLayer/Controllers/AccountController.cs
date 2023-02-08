using KinoPoisk.DomainLayer.DTOs.UserDTO;
using KinoPoisk.DomainLayer.Intarfaces.Services;
using KinoPoisk.PresentationLayer.Controllers.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace KinoPoisk.PresentationLayer.Controllers
{
    [Authorize]
    public class AccountController : BaseController {
        private readonly IUserService _userService;

        public AccountController(IUserService userService) {
            _userService = userService;
        }

        [HttpPost("register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register([FromBody] UserDTO userDto) {
            var result = await _userService.CreateAsync(userDto);
            return GetResult(result, (int)HttpStatusCode.Created);
        }

        [HttpGet("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromQuery] LoginDTO loginData) {
            var result = await _userService.LoginAsync(loginData);
            return GetResult(result, (int)HttpStatusCode.OK);
        }

        [HttpPut("confirm-email")]
        public async Task<IActionResult> ConfirmEmail() {
            var result = await _userService.ConfirmEmailAsync();
            return GetResult(result, (int)HttpStatusCode.NoContent);
        }

        [HttpGet("confirm-email")]
        [AllowAnonymous]
        public async Task<IActionResult> ConfirmEmail([FromQuery] string token, string email) {
            var result = await _userService.VerificationConfirmationTokenAsync(token, email);
            return GetResult(result, (int)HttpStatusCode.OK);
        }

        [HttpPost("forgot-password")]
        [AllowAnonymous]
        public async Task<IActionResult> ForgotPassword([FromQuery] string email) {
            var result = await _userService.SendResetPasswordEmailAsync(email);
            return GetResult(result, (int)HttpStatusCode.NoContent);
        }

        [HttpPost("reset-password")]
        [AllowAnonymous]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordDTO resetPasswordData) {
            var result = await _userService.ResetPasswordAsync(resetPasswordData);
            return GetResult(result, (int)HttpStatusCode.NoContent); 
        }

        [HttpPut("change-password")]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordDTO changePasswordData) {
            var userId = GetAuthUserId();
            var result = await _userService.ChangePasswordAsync(changePasswordData);
            return GetResult(result, (int)HttpStatusCode.NoContent); 
        }

        [HttpPut("change-email")]
        public async Task<IActionResult> ChangeEmail([FromQuery] string newEmail) {
            var userId = GetAuthUserId();
            var result = await _userService.ChangeEmailAsync(newEmail);
            return GetResult(result, (int)HttpStatusCode.NoContent);
        }
    }
}
