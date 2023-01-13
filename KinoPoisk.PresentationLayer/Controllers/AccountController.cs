using KinoPoisk.DomainLayer.DTOs.UserDTO;
using KinoPoisk.DomainLayer.Intarfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KinoPoisk.PresentationLayer.Controllers {
    [Authorize]
    public class AccountController : BaseController {
        private readonly IUserService _userService;

        public AccountController(IUserService userService) {
            _userService = userService;
        }

        [HttpPost("register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register([FromBody] UserDTO userDto) {
            var result = await _userService.RegisterAsync(userDto);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpGet("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromQuery] LoginDTO loginData) {
            var result = await _userService.LoginAsync(loginData);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPut("confirm-email")]
        public async Task<IActionResult> ConfirmEmail() {
            var userId = GetAuthUserId();
            var result = await _userService.ConfirmEmailAsync();
            return Ok(result);
        }

        [HttpGet("confirm-email")]
        [AllowAnonymous]
        public async Task<IActionResult> ConfirmEmail([FromQuery] string token, string email) {
            var result = await _userService.VerificationConfirmationTokenAsync(token, email);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("forgot-password")]
        [AllowAnonymous]
        public async Task<IActionResult> ForgotPassword([FromQuery] string email) {
            var result = await _userService.SendResetPasswordEmailAsync(email);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("reset-password")]
        [AllowAnonymous]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordDTO resetPasswordData) {
            var result = await _userService.ResetPasswordAsync(resetPasswordData);
            return result.Success ? Ok(result) : BadRequest(result); 
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUserData([FromBody] UpdateUserDTO userDTO) {
            var result = await _userService.UpdateUserDataAsync(userDTO);
            return result.Success ? Ok(result) : BadRequest(result); 
        }

        [HttpPut("change-password")]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordDTO changePasswordData) {
            var userId = GetAuthUserId();
            var result = await _userService.ChangePasswordAsync(changePasswordData);
            return result.Success ? Ok(result) : BadRequest(result); 
        }

        [HttpPut("change-email")]
        public async Task<IActionResult> ChangeEmail([FromQuery] string newEmail) {
            var userId = GetAuthUserId();
            var result = await _userService.ChangeEmailAsync(newEmail);
            return result.Success ? Ok(result) : BadRequest(result);
        }
    }
}
