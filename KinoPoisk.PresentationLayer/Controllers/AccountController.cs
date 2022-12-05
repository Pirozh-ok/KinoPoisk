using KinoPoisk.DomainLayer;
using KinoPoisk.DomainLayer.DTOs.UserDTO;
using KinoPoisk.DomainLayer.Intarfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KinoPoisk.PresentationLayer.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AccountController : ControllerBase {
        private readonly IUserService _userService; 

        public AccountController(IUserService userService, IAuthService authService) {
            _userService = userService;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register([FromBody] CreateUserDTO userDto) {
            var result = await _userService.RegisterAsync(userDto);
            return result is ErrorResult ? BadRequest(result) : Ok(result);
        }

        [HttpGet("/login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromQuery] LoginDTO loginData) {
            var result = await _userService.LoginAsync(loginData);
            return result is ErrorResult ? BadRequest(result) : Ok(result);
        }

        [HttpGet("/logout")]
        public async Task<IActionResult> Logout() {
            await _userService.LogoutAsync();
            return Ok(); 
        }

        [HttpGet("/test")]
        public async Task<IActionResult> Test() {
            return Ok("TEST");
        }
    }
}
