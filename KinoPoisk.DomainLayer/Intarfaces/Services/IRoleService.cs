using KinoPoisk.DomainLayer.DTOs;

namespace KinoPoisk.DomainLayer.Intarfaces.Services {
    public interface IRoleService {
        Task<ServiceResult> CreateRoleAsync(RoleDTO dto);
        Task<ServiceResult> DeleteRoleByIdAsync(Guid id);
        Task<ServiceResult> DeleteRoleByNameAsync(string name);
        Task<ServiceResult> UpdateRoleAsync(RoleDTO dto);
        Task<ServiceResult> GetRolesAsync();
        Task<ServiceResult> AddRolesToUserAsync(Guid userId, string[] roleNames);
        Task<ServiceResult> RemoveRolesFromUserAsync(Guid userId, string[] roleNames);
        Task<ServiceResult> GetUserRolesAsync(Guid userId); 
    }
}
