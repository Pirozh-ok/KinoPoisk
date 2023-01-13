using KinoPoisk.DomainLayer.DTOs;
using KinoPoisk.DomainLayer.Entities;
using KinoPoisk.DomainLayer.Intarfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace KinoPoisk.PresentationLayer.Controllers {
    [Authorize(Roles = "Admin")]
    public class RoleController : BaseController {
        private readonly IRoleService _roleService;

        public RoleController(RoleManager<ApplicationRole> roleManager,
            UserManager<ApplicationUser> userManager,
            IRoleService roleService) {
            _roleService = roleService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateRole(string name) {
            var result = await _roleService.CreateRoleAsync(new RoleDTO { Name = name });
            return result.Success ? StatusCode((int)HttpStatusCode.Created) : BadRequest(result.Errors);
        }

        [HttpDelete("{name}")]
        public async Task<IActionResult> DeleteRoleById(string name) {
            var result = await _roleService.DeleteRoleByNameAsync(name);
            return result.Success ? StatusCode((int)HttpStatusCode.NoContent) : BadRequest(result.Errors);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateRole([FromBody] RoleDTO role) {
            var result = await _roleService.UpdateRoleAsync(role);
            return result.Success ? StatusCode((int)HttpStatusCode.NoContent) : BadRequest(result.Errors);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRoles(){
            var result = await _roleService.GetRolesAsync();
            return result.Success ? Ok(result) : BadRequest(result.Errors);
        }

        [HttpGet("user-roles/{id}")]
        public async Task<IActionResult> GetUserRoles(Guid id) {
            var result = await _roleService.GetUserRolesAsync(id);
            return result.Success ? Ok(result) : BadRequest(result.Errors);
        }

        [HttpPut("add-roles")]
        public async Task<IActionResult> AddRolesToUser([FromQuery] Guid userId, [FromQuery] string[] roles) {
            var result = await _roleService.AddRolesToUserAsync(userId, roles);
            return result.Success ? StatusCode((int)HttpStatusCode.NoContent) : BadRequest(result);
        }

        [HttpPut("remove-roles")]
        public async Task<IActionResult> RemoveRolesFromUser([FromQuery] Guid userId, [FromQuery] string[] roles) {
            var result = await _roleService.RemoveRolesFromUserAsync(userId, roles);
            return result.Success ? StatusCode((int)HttpStatusCode.NoContent) : BadRequest(result);
        }
    }
}
