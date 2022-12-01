using KinoPoisk.BusinessLogicLayer.Services.Implementations;
using KinoPoisk.DomainLayer.DTOs.UserDTO;
using KinoPoisk.DomainLayer.Intarfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace KinoPoisk.PresentationLayer.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase {
        private readonly IUserService _userService;

        public AccountController(IUserService userService) {
            _userService = userService;
        }

        [HttpPost] 
        public async Task<IActionResult> Register([FromBody] CreateUserDTO userDto) {
            var result = await _userService.RegisterAsync(userDto); 
            return Ok(result);
        }

        [HttpGet("/login")]
        public async Task<IActionResult> Login([FromQuery] LoginDTO loginData) {
            var result = await _userService.LoginAsync(loginData);
            return Ok(result);
        }
    }
}
