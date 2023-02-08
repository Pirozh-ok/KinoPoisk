using KinoPoisk.DataAccessLayer;
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
            return GetResult(result);
        }

        [HttpPost]
        [AllowAnonymous]
        public override async Task<IActionResult> CreateAsync(UserDTO dto) {
            var result = await _service.CreateAsync(dto);
            return result.Success ? StatusCode((int)HttpStatusCode.Created) : BadRequest(result);
        }

        [HttpGet]
        [Authorize(Roles = Constants.NameRoleAdmin)]
        public override async Task<IActionResult> GetAllAsync() {
            var result = await _service.GetAsync<GetUserDTO>();
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpGet("{userId}")]
        [Authorize(Roles = Constants.NameRoleAdmin)]
        public override async Task<IActionResult> GetByIdAsync(Guid userId) {
            var result = await _service.GetByIdAsync<GetUserDTO>(userId);
            return result.Success ? Ok(result) : BadRequest(result);
        }
    }
}
