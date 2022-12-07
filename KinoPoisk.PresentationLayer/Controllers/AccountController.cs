using KinoPoisk.DomainLayer;
using KinoPoisk.DomainLayer.DTOs.UserDTO;
using KinoPoisk.DomainLayer.Intarfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.Security.Policy;

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

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register([FromBody] CreateUserDTO userDto) {
            var result = await _userService.RegisterAsync(userDto);
            return result is ErrorResult ? BadRequest(result) : Ok(result);
        }

        [HttpGet("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromQuery] LoginDTO loginData) {
            var result = await _userService.LoginAsync(loginData);
            return result is ErrorResult ? BadRequest(result) : Ok(result);
        }

        [HttpPut("confirm-email")]
        public async Task<IActionResult> ConfirmEmail() {
            var userEmail = User.Claims.FirstOrDefault(x => x.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress").Value;
            await _userService.ConfirmEmailAsync(userEmail);
            return Ok(); 
        }

        [HttpGet("confirm-email")]
        [AllowAnonymous]
        public async Task<IActionResult> Test([FromQuery] string token, string email) {
            var result = await _userService.VerificationConfirmationToken(token, email);
            return result is ErrorResult ? BadRequest(result) : Ok(result);
        }
    }
}
