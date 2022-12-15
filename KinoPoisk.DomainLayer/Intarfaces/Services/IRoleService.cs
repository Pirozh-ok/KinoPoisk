using KinoPoisk.DomainLayer.DTOs;

namespace KinoPoisk.DomainLayer.Intarfaces.Services {
    public interface IRoleService {
        Task<Result> CreateRoleAsync(RoleDTO dto);
        Task<Result> DeleteRoleByIdAsync(Guid id);
        Task<Result> DeleteRoleByName(string name);
        Task<Result> UpdateRole(RoleDTO dto);
        Task<Result> GetRoles();
        Task<Result> AddRolesToUser(Guid userId, string[] roleNames);
        Task<Result> RemoveRolesFromUser(Guid userId, string[] roleNames);
        Task<Result> GetUserRoles(Guid userId); 
    }
}
