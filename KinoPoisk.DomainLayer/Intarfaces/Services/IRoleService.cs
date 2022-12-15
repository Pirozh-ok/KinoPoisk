using KinoPoisk.DomainLayer.DTOs;
using KinoPoisk.DomainLayer.DTOs.UserDTO;

namespace KinoPoisk.DomainLayer.Intarfaces.Services {
    public interface IRoleService {
        Task<Result> CreateRoleAsync(RoleDTO dto);
        Task<Result> DeleteRoleByIdAsync(Guid id);
        Task<Result> DeleteRoleByNameAsync(string name);
        Task<Result> UpdateRoleAsync(RoleDTO dto);
        Task<Result> GetRolesAsync();
        Task<Result> AddRolesToUserAsync(Guid userId, string[] roleNames);
        Task<Result> RemoveRolesFromUserAsync(Guid userId, string[] roleNames);
        Task<Result> GetUserRolesAsync(Guid userId); 
    }
}
