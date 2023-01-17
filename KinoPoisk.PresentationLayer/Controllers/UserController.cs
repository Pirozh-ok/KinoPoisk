using KinoPoisk.DataAccessLayer;
using KinoPoisk.DomainLayer.DTOs.UserDTO;
using KinoPoisk.DomainLayer.Intarfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace KinoPoisk.PresentationLayer.Controllers {
    [Authorize]
    public class UserController : BaseController {
        private readonly IUserService _userService;

        public UserController(IUserService userService) {
            _userService = userService;
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUser(UpdateUserDTO dto) {
            var result = await _userService.UpdateUserDataAsync(dto);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteUser(Guid userId) {
            var result = await _userService.DeleteUserAsync(userId);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpGet]
        [Authorize(Roles = Constants.NameRoleAdmin)]
        public async Task<IActionResult> GetAllUsers() {
            var result = await _userService.GetAllUsersAsync();
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpGet("{userId}")]
        [Authorize(Roles = Constants.NameRoleAdmin)]
        public async Task<IActionResult> GetUserById(Guid userId) {
            var result = await _userService.GetUserById(userId);
            return result.Success ? Ok(result) : BadRequest(result);
        }
    }
}
