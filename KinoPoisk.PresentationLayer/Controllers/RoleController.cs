using KinoPoisk.DataAccessLayer;
using KinoPoisk.DomainLayer;
using KinoPoisk.DomainLayer.Entities;
using KinoPoisk.DomainLayer.Intarfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace KinoPoisk.PresentationLayer.Controllers {
    [Route("api/[controller]")]
    [Authorize(Roles = "Admin")]
    [ApiController]
    public class RoleController : ControllerBase {
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IRoleService _roleService; 

        public RoleController(RoleManager<ApplicationRole> roleManager, 
            UserManager<ApplicationUser> userManager,
            IRoleService roleService) {
            _roleManager = roleManager;
            _userManager = userManager;
            _roleService = roleService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateRole(string name) {

            if(!string.IsNullOrEmpty(name)) { 
                var result = await _roleManager.CreateAsync(new ApplicationRole { Name = name });
                return result.Succeeded? Ok(result) : BadRequest();
            }

            return BadRequest();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteRole(Guid id) {
            var role = await _roleManager.FindByIdAsync(id.ToString());

            if(role is not null) {
                var result = await _roleManager.DeleteAsync(role);
                return result.Succeeded? Ok(result) : BadRequest();
            }
            
            return BadRequest();
        }

        //[HttpPut]
        //public async Task<IActionResult> GiveAllRoles([FromQuery] Guid id) {
        //    var user = await _userManager.FindByIdAsync(id.ToString());

        //    if(user is not null) {
        //        var roles = _roleManager.Roles.ToList();

        //        foreach(var role in roles) {
        //            await _userManager.AddToRoleAsync(user, role.ToString()); 
        //        }; 
        //    }

        //    return Ok(); 
        //}

        [HttpGet]
        public async Task<IActionResult> GetAllRoles() => Ok(_roleManager.Roles.ToList());

        [HttpPut]
        public async Task<IActionResult> AddRolesToUser([FromQuery] Guid userId, [FromQuery] string[] roles) {
            var result = await _roleService.AddRolesToUser(userId, roles);
            return result is ErrorResult ? BadRequest(result) : Ok(result);
        }
    }
}
