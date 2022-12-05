using KinoPoisk.BusinessLogicLayer.Services.Implementations;
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
        private readonly IAuthService _authService; 

        public AccountController(IUserService userService, IAuthService authService) {
            _userService = userService;
            _authService = authService;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register([FromBody] CreateUserDTO userDto) {
            var result = await _userService.RegisterAsync(userDto); 
            return GetAuthResult(result);
        }

        [HttpGet("/login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromQuery] LoginDTO loginData) {
            var result = await _userService.LoginAsync(loginData);
            return GetAuthResult(result);
        }

        [HttpGet("/logout")]
        public async Task<IActionResult> Logout() {
            await _userService.LogoutAsync();
            return Ok(); 
        }

        private IActionResult GetAuthResult(Result result) {
            if (result is not ErrorResult) {
                var user = ((SuccessResult<GetUserDTO>)result).Data;

                return Ok(new {
                    AccessToken = _authService.GenerateToken(new JwtGenerateDTO {
                        Email = user.Email,
                        UserId = user.Id,
                        UserName = user.UserName
                    }),
                    Data = user
                });
            }

            return BadRequest(result);
        }
    }
}
