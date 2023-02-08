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
            return GetResult(result, (int)HttpStatusCode.OK);
        }

        [HttpPut("add-roles")]
        public async Task<IActionResult> AddRolesToUser([FromQuery] Guid userId, [FromQuery] string[] roles) {
            var result = await _service.AddRolesToUserAsync(userId, roles);
            return GetResult(result, (int)HttpStatusCode.NoContent);
        }

        [HttpPut("remove-roles")]
        public async Task<IActionResult> RemoveRolesFromUser([FromQuery] Guid userId, [FromQuery] string[] roles) {
            var result = await _service.RemoveRolesFromUserAsync(userId, roles);
            return GetResult(result, (int)HttpStatusCode.NoContent);
        }
    }
}
