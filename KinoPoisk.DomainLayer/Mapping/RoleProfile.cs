using AutoMapper;
using KinoPoisk.DomainLayer.DTOs.RoleDto;
using KinoPoisk.DomainLayer.Entities;

namespace KinoPoisk.DomainLayer.Mapping {
    public class RoleProfile : Profile {
        public RoleProfile() {
            CreateMap<RoleDTO, ApplicationRole>();
            CreateMap<ApplicationRole, GetRoleDto>();
        }
    }
}
