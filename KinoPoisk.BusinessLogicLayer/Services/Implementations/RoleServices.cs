using AutoMapper;
using AutoMapper.QueryableExtensions;
using KinoPoisk.BusinessLogicLayer.Services.Base;
using KinoPoisk.DataAccessLayer;
using KinoPoisk.DomainLayer;
using KinoPoisk.DomainLayer.DTOs.RoleDto;
using KinoPoisk.DomainLayer.Entities;
using KinoPoisk.DomainLayer.Intarfaces.Services;
using KinoPoisk.DomainLayer.Resources;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace KinoPoisk.BusinessLogicLayer.Services.Implementations
{
    public class RoleServices : BaseEntityService<ApplicationRole, Guid, RoleDTO>, IRoleService {
        private readonly UserManager<ApplicationUser> _userManager; 
        private readonly RoleManager<ApplicationRole> _roleManager;

        public RoleServices(
            UserManager<ApplicationUser> userManager, 
            RoleManager<ApplicationRole> roleManager,
            IUnitOfWork unitOfWork,
            IMapper mapper) : base(unitOfWork, mapper) {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<ServiceResult> AddRolesToUserAsync(Guid userId, string[] roleNames) {
            var user = await _userManager.FindByIdAsync(userId.ToString());

            if (user is null) {
                return ServiceResult.Fail(UserResource.NotFound);
            }

            var validationResult = RolesIsExist(roleNames);

            if (validationResult.Failure) {
                return validationResult;
            }

            var result = await _userManager.AddToRolesAsync(user, roleNames);

            if (result.Succeeded) {
                return ServiceResult.Ok(RoleResource.RoleAddedToUser); 
            }

            return ServiceResult.Fail(result.Errors
                .Select(x => x.Description)
                .ToList()); 
        }

        public override async Task<ServiceResult> CreateAsync(RoleDTO dto) {
            var validationResult = Validate(dto);

            if (validationResult.Failure) {
                return validationResult;
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

        public override async Task<ServiceResult> DeleteAsync(Guid id) {
            var role = await _roleManager.FindByIdAsync(id.ToString());
            return await DeleteRole(role);              
        }

        public async Task<ServiceResult> DeleteAsync(string name) {
            var role = await _roleManager.FindByNameAsync(name);
            return await DeleteRole(role);
        }

        public override ServiceResult Get<GetRoleDto>() => 
            ServiceResult.Ok(_roleManager.Roles.
                ProjectTo<GetRoleDto>(_mapper.ConfigurationProvider)
                .ToList());

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

            var validationResult = RolesIsExist(roleNames); 

            if (validationResult.Failure) {
                return validationResult;
            }

            var result = await _userManager.RemoveFromRolesAsync(user, roleNames);

            if (result.Succeeded) {
                return ServiceResult.Ok(RoleResource.RoleAddedToUser);
            }

            return ServiceResult.Fail(result.Errors
                .Select(x => x.Description)
                .ToList());
        }

        public override async Task<ServiceResult> UpdateAsync(RoleDTO dto) {
            var validationResult = Validate(dto); 

            if(validationResult.Failure) {
                return validationResult; 
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

        protected override ServiceResult Validate(RoleDTO dto) {
            var errors = new List<string>();

            if(dto is null) {
                return ServiceResult.Fail(RoleResource.NullArgument);
            }

            if(string.IsNullOrEmpty(dto.Name)) {
                return ServiceResult.Fail(RoleResource.NullOrEmptyName); 
            }

            if(dto.Name.Length > Constants.MaxLenOfName) {
                errors.Add(string.Format(RoleResource.NameExceedMaxLen, Constants.MaxLenOfName));
            }

            if(dto.Name.Length < Constants.MinLenOfName) {
                errors.Add(string.Format(RoleResource.NameLessMinLen, Constants.MinLenOfName));
            }

            return errors.Count > 0 ? ServiceResult.Fail(errors) : ServiceResult.Ok(); 
        }

        private ServiceResult RolesIsExist(string[] roleNames) {
            var errors = new List<string>();
            var existingRoles = _roleManager.Roles
                .Select(x => x.Name)
                .ToHashSet();

            foreach (var role in roleNames) {
                if (existingRoles.Contains(role.ToLower())) {
                    errors.Add(string.Format(RoleResource.RoleNotExist, role));
                }
            }

            return errors.Count > 0 ? ServiceResult.Fail(errors) : ServiceResult.Ok(); 
        }
    }
}
