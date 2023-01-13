using KinoPoisk.DomainLayer;
using KinoPoisk.DomainLayer.DTOs.UserDTO;
using KinoPoisk.DomainLayer.Intarfaces.Services;
using KinoPoisk.DomainLayer.Resources;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace KinoPoisk.PresentationLayer.Controllers {
    [Route("api/[controller]/")]
    [ApiController]
    [Authorize]
    public class AccountController : ControllerBase {
        private readonly IUserService _userService;
        private readonly IEmailService _emailService;

        public AccountController(IUserService userService, IEmailService emailService) {
            _userService = userService;
            _emailService = emailService;
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
        [Authorize]
        public async Task<IActionResult> ConfirmEmail() {
            var userId = User.Claims.FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Jti)?.Value;

            if (string.IsNullOrEmpty(userId)) {
                return Unauthorized();
            }

            var result = await _userService.ConfirmEmailAsync(userId);
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
        [Authorize]
        public async Task<IActionResult> UpdateUserData([FromBody] UpdateUserDTO userDTO) {
            var result = await _userService.UpdateUserDataAsync(userDTO);
            return result.Success ? Ok(result) : BadRequest(result); 
        }

        [HttpPut("change-password")]
        [Authorize]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordDTO changePasswordData) {
            var userId = User.Claims.FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Jti)?.Value;

            if(string.IsNullOrEmpty(userId) ) {
                return Unauthorized(); 
            }

            var result = await _userService.ChangePasswordAsync(changePasswordData, userId);
            return result.Success ? Ok(result) : BadRequest(result); 
        }

        [HttpPut("change-email")]
        [Authorize]
        public async Task<IActionResult> ChangeEmail([FromQuery] string newEmail) {
            var userId = User.Claims.FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Jti)?.Value;

            if (string.IsNullOrEmpty(userId)) {
                return Unauthorized();
            }

            var result = await _userService.ChangeEmailAsync(userId, newEmail);
            return result.Success ? Ok(result) : BadRequest(result);
        }
    }
}
