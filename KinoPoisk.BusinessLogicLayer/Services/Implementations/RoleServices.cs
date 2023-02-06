using KinoPoisk.DataAccessLayer;
using KinoPoisk.DomainLayer;
using KinoPoisk.DomainLayer.DTOs;
using KinoPoisk.DomainLayer.Entities;
using KinoPoisk.DomainLayer.Intarfaces.Services;
using KinoPoisk.DomainLayer.Resources;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace KinoPoisk.BusinessLogicLayer.Services.Implementations {
    public class RoleServices : IRoleService {
        private readonly UserManager<ApplicationUser> _userManager; 
        private readonly RoleManager<ApplicationRole> _roleManager;

        public RoleServices(UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager) {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<ServiceResult> AddRolesToUserAsync(Guid userId, string[] roleNames) {
            var user = await _userManager.FindByIdAsync(userId.ToString());

            if (user is null) {
                return ServiceResult.Fail(UserResource.NotFound);
            }

            var errors = RolesIsExist(roleNames);

            if (errors.Count > 0) {
                return ServiceResult.Fail(errors);
            }

            var result = await _userManager.AddToRolesAsync(user, roleNames);

            if (result.Succeeded) {
                return ServiceResult.Ok(RoleResource.RoleAddedToUser); 
            }

            return ServiceResult.Fail(result.Errors
                .Select(x => x.Description)
                .ToList()); 
        }

        public async Task<ServiceResult> CreateRoleAsync(RoleDTO dto) {
            var errors = ValidateRole(dto);

            if (errors.Count() > 0) {
                return ServiceResult.Fail(errors);
            }

            var result = await _roleManager.CreateAsync(
                new ApplicationRole {
                    Name = dto.Name
                });

            if (result.Succeeded) {
                return ServiceResult.Ok(RoleResource.RoleCreated);
            }

            return ServiceResult.Fail(result.Errors
                .Select(x => x.Description)
                .ToList());
        }

        public async Task<ServiceResult> DeleteRoleByIdAsync(Guid id) {
            var role = await _roleManager.FindByNameAsync(id.ToString());
            return await DeleteRole(role);              
        }

        public async Task<ServiceResult> DeleteRoleByNameAsync(string name) {
            var role = await _roleManager.FindByNameAsync(name);
            return await DeleteRole(role);
        }

        public async Task<ServiceResult> GetRolesAsync() => ServiceResult.Ok(await _roleManager.Roles.ToListAsync());

        public async Task<ServiceResult> GetUserRolesAsync(Guid userId) {
            var user = await _userManager.FindByIdAsync(userId.ToString());
            
            if(user is null) {
                return ServiceResult.Fail(UserResource.NotFound); 
            }

            return ServiceResult.Ok(await _userManager.GetRolesAsync(user));
        }

        public async Task<ServiceResult> RemoveRolesFromUserAsync(Guid userId,string[] roleNames) {
            var user = await _userManager.FindByIdAsync(userId.ToString());

            if (user is null) {
                return ServiceResult.Fail(UserResource.NotFound);
            }

            var errors = RolesIsExist(roleNames); 

            if (errors.Count > 0) {
                return ServiceResult.Fail(errors);
            }

            var result = await _userManager.RemoveFromRolesAsync(user, roleNames);

            if (result.Succeeded) {
                return ServiceResult.Ok(RoleResource.RoleAddedToUser);
            }

            return ServiceResult.Fail(result.Errors
                .Select(x => x.Description)
                .ToList());
        }

        public async Task<ServiceResult> UpdateRoleAsync(RoleDTO dto) {
            var errors = ValidateRole(dto); 

            if(errors.Count() > 0) {
                return ServiceResult.Fail(errors); 
            }

            var role = await _roleManager.FindByIdAsync(dto.Id.ToString());

            if(role is null) {
                return ServiceResult.Fail(RoleResource.NotFound); 
            }

            role.Name = dto.Name; 
            var result = await _roleManager.UpdateAsync(role);

            if (result.Succeeded) {
                return ServiceResult.Ok(RoleResource.RoleUpdated); 
            }

            return ServiceResult.Fail(result.Errors
                .Select(x => x.Description)
                .ToList()); 
        }

        private async Task<ServiceResult> DeleteRole(ApplicationRole role) {
            if (role is null) {
                return ServiceResult.Fail(RoleResource.NotFound);
            }

            var result = await _roleManager.DeleteAsync(role);

            if (result.Succeeded) {
                return ServiceResult.Ok(RoleResource.RoleDeleted);
            }

            return ServiceResult.Fail(result.Errors
                .Select(x => x.Description)
                .ToList());
        }

        private List<string> ValidateRole(RoleDTO dto) {
            var errors = new List<string>();

            if(dto is null) {
                return new List<string>() { RoleResource.NullArgument };
            }

            if(string.IsNullOrEmpty(dto.Name)) {
                return new List<string>() { RoleResource.NullOrEmptyName }; 
            }

            if(dto.Name.Length > Constants.MaxLenOfName) {
                errors.Add(string.Format(RoleResource.NameExceedMaxLen, Constants.MaxLenOfName));
            }

            if(dto.Name.Length < Constants.MinLenOfName) {
                errors.Add(string.Format(RoleResource.NameLessMinLen, Constants.MinLenOfName));
            }

            return errors; 
        }

        private List<string> RolesIsExist(string[] roleNames) {
            var errors = new List<string>();
            var existingRoles = _roleManager.Roles
                .Select(x => x.Name)
                .ToHashSet();

            foreach (var role in roleNames) {
                if (existingRoles.Contains(role)) {
                    errors.Add(string.Format(RoleResource.RoleNotExist, role));
                }
            }

            return errors; 
        }
    }
}
