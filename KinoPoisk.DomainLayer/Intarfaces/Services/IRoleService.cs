using KinoPoisk.DomainLayer.DTOs.GenreDTO;
using KinoPoisk.DomainLayer.DTOs.RoleDto;

namespace KinoPoisk.DomainLayer.Intarfaces.Services
{
    public interface IRoleService : IBaseEntityService<Guid, RoleDTO> {
        Task<ServiceResult> AddRolesToUserAsync(Guid userId, string[] roleNames);
        Task<ServiceResult> RemoveRolesFromUserAsync(Guid userId, string[] roleNames);
        Task<ServiceResult> GetUserRolesAsync(Guid userId); 
    }
}
