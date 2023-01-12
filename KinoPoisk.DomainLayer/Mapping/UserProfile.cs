using AutoMapper;
using KinoPoisk.DomainLayer.DTOs.UserDTO;
using KinoPoisk.DomainLayer.Entities;

namespace KinoPoisk.DomainLayer.Mapping {
    public class UserProfile : Profile{
        public UserProfile() {
            CreateMap<UserDTO, ApplicationUser>();
            CreateMap<UpdateUserDTO, ApplicationUser>(); 
            CreateMap<ApplicationUser, GetUserDTO>();
        }
    }
}
