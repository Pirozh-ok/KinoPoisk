using KinoPoisk.BusinessLogicLayer.Services.Implementations;
using KinoPoisk.DataAccessLayer;
using KinoPoisk.DomainLayer.DTOs.MovieDTOs;
using KinoPoisk.DomainLayer.DTOs.Pageable;
using KinoPoisk.DomainLayer.DTOs.UserDTO;
using KinoPoisk.DomainLayer.Intarfaces.Services;
using KinoPoisk.PresentationLayer.Controllers.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace KinoPoisk.PresentationLayer.Controllers {
    [Authorize]
    public class UserController : CrudControllerBase<IUserService, UserDTO, GetUserDTO, Guid > {
        public UserController(IUserService userService) : base (userService) {
        }

        [HttpGet("me")]
        public async Task<IActionResult> GetMyInfo() {
            var currentUserId = GetAuthUserId();
            var result = await _service.GetByIdAsync<GetUserDTO>(Guid.Parse(currentUserId));
            return GetResult(result, (int)HttpStatusCode.OK);
        }

        [HttpPost]
        [AllowAnonymous]
        public override async Task<IActionResult> CreateAsync(UserDTO dto) {
            var result = await _service.CreateAsync(dto);
            return GetResult(result, (int)HttpStatusCode.Created);
        }

        [HttpGet]
        [Authorize(Roles = Constants.NameRoleAdmin)]
        public override async Task<IActionResult> GetAllAsync() {
            var result = await _service.GetAsync<GetUserDTO>();
            return GetResult(result, (int)HttpStatusCode.OK);
        }

        [HttpGet("{userId}")]
        [Authorize(Roles = Constants.NameRoleAdmin)]
        public override async Task<IActionResult> GetByIdAsync(Guid userId) {
            var result = await _service.GetByIdAsync<GetUserDTO>(userId);
            return GetResult(result, (int)HttpStatusCode.OK);
        }

        [AllowAnonymous]
        [HttpGet("search")]
        public async Task<IActionResult> GetFilteringUsers([FromQuery] PageableUserRequestDto filters) {
            var result = _service.SearchFor<GetUserDTO>(filters);
            return GetResult(result, (int)HttpStatusCode.OK);
        }

        [HttpPut("change-password")]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordDTO changePasswordData) {
            var userId = GetAuthUserId();
            var result = await _service.ChangePasswordAsync(changePasswordData);
            return GetResult(result, (int)HttpStatusCode.NoContent);
        }

        [HttpPut("change-email")]
        public async Task<IActionResult> ChangeEmail([FromQuery] string newEmail) {
            var userId = GetAuthUserId();
            var result = await _service.ChangeEmailAsync(newEmail);
            return GetResult(result, (int)HttpStatusCode.NoContent);
        }
    }
}
