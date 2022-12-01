using AutoMapper;
using KinoPoisk.DomainLayer.DTOs;
using KinoPoisk.DomainLayer.DTOs.UserDTO;
using KinoPoisk.DomainLayer.Entities;

namespace KinoPoisk.DomainLayer.Mapping {
    public class UserProfile : Profile{
        public UserProfile() {
            CreateMap<UpdateUserDTO, ApplicationUser>();
            CreateMap<CreateUserDTO, ApplicationUser>();
            CreateMap<ApplicationUser, GetUserDTO>();
        }
    }
}
