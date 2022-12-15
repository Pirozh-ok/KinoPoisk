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

        public async Task<Result> AddRolesToUserAsync(Guid userId, string[] roleNames) {
            var user = await _userManager.FindByIdAsync(userId.ToString());

            if (user is null) {
                return Result.Fail(UserResource.NotFound);
            }

            var errors = RolesIsExist(roleNames);

            if (errors.Count > 0) {
                return Result.Fail(errors);
            }

            var result = await _userManager.AddToRolesAsync(user, roleNames);

            if (result.Succeeded) {
                return Result.Ok(RoleResource.RoleAddedToUser); 
            }

            return Result.Fail(result.Errors
                .Select(x => x.Description)
                .ToList()); 
        }

        public async Task<Result> CreateRoleAsync(RoleDTO dto) {
            var errors = ValidateRole(dto);

            if (errors.Count() > 0) {
                return Result.Fail(errors);
            }

            var result = await _roleManager.CreateAsync(
                new ApplicationRole {
                    Name = dto.Name
                });

            if (result.Succeeded) {
                return Result.Ok(RoleResource.RoleCreated);
            }

            return Result.Fail(result.Errors
                .Select(x => x.Description)
                .ToList());
        }

        public async Task<Result> DeleteRoleByIdAsync(Guid id) {
            var role = await _roleManager.FindByNameAsync(id.ToString());
            return await DeleteRole(role);              
        }

        public async Task<Result> DeleteRoleByNameAsync(string name) {
            var role = await _roleManager.FindByNameAsync(name);
            return await DeleteRole(role);
        }

        public async Task<Result> GetRolesAsync() => Result.Ok(await _roleManager.Roles.ToListAsync());

        public async Task<Result> GetUserRolesAsync(Guid userId) {
            var user = await _userManager.FindByIdAsync(userId.ToString());
            
            if(user is null) {
                return Result.Fail(UserResource.NotFound); 
            }

            return Result.Ok(await _userManager.GetRolesAsync(user));
        }

        public async Task<Result> RemoveRolesFromUserAsync(Guid userId,string[] roleNames) {
            var user = await _userManager.FindByIdAsync(userId.ToString());

            if (user is null) {
                return Result.Fail(UserResource.NotFound);
            }

            var errors = RolesIsExist(roleNames); 

            if (errors.Count > 0) {
                return Result.Fail(errors);
            }

            var result = await _userManager.RemoveFromRolesAsync(user, roleNames);

            if (result.Succeeded) {
                return Result.Ok(RoleResource.RoleAddedToUser);
            }

            return Result.Fail(result.Errors
                .Select(x => x.Description)
                .ToList());
        }

        public async Task<Result> UpdateRoleAsync(RoleDTO dto) {
            var errors = ValidateRole(dto); 

            if(errors.Count() > 0) {
                return Result.Fail(errors); 
            }

            var role = await _roleManager.FindByIdAsync(dto.Id.ToString());

            if(role is null) {
                return Result.Fail(RoleResource.NotFound); 
            }

            role.Name = dto.Name; 
            var result = await _roleManager.UpdateAsync(role);

            if (result.Succeeded) {
                return Result.Ok(RoleResource.RoleUpdated); 
            }

            return Result.Fail(result.Errors
                .Select(x => x.Description)
                .ToList()); 
        }

        private async Task<Result> DeleteRole(ApplicationRole role) {
            if (role is null) {
                return Result.Fail(RoleResource.NotFound);
            }

            var result = await _roleManager.DeleteAsync(role);

            if (result.Succeeded) {
                return Result.Ok(RoleResource.RoleDeleted);
            }

            return Result.Fail(result.Errors
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
