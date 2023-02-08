using KinoPoisk.DataAccessLayer;
using KinoPoisk.DomainLayer.DTOs.RoleDto;
using KinoPoisk.DomainLayer.Entities;
using KinoPoisk.DomainLayer.Intarfaces.Services;
using KinoPoisk.PresentationLayer.Controllers.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace KinoPoisk.PresentationLayer.Controllers
{
    [Authorize(Roles = Constants.NameRoleAdmin)]
    public class RoleController : CrudControllerBase<IRoleService, RoleDTO, GetRoleDto, Guid> {

        public RoleController(IRoleService roleService) : base (roleService){
        }
        [HttpGet("user-roles/{id}")]
        public async Task<IActionResult> GetUserRoles(Guid id) {
            var result = await _service.GetUserRolesAsync(id);
            return result.Success ? Ok(result) : BadRequest(result.Errors);
        }

        [HttpPut("add-roles")]
        public async Task<IActionResult> AddRolesToUser([FromQuery] Guid userId, [FromQuery] string[] roles) {
            var result = await _service.AddRolesToUserAsync(userId, roles);
            return result.Success ? StatusCode((int)HttpStatusCode.NoContent) : BadRequest(result);
        }

        [HttpPut("remove-roles")]
        public async Task<IActionResult> RemoveRolesFromUser([FromQuery] Guid userId, [FromQuery] string[] roles) {
            var result = await _service.RemoveRolesFromUserAsync(userId, roles);
            return result.Success ? StatusCode((int)HttpStatusCode.NoContent) : BadRequest(result);
        }
    }
}
