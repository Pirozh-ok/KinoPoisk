using AutoMapper;
using KinoPoisk.DomainLayer.DTOs.AgeCategoriesDTO;
using KinoPoisk.DomainLayer.Entities;

namespace KinoPoisk.DomainLayer.Mapping {
    public class AgeCategoryProfile : Profile {
        public AgeCategoryProfile() {
            CreateMap<AgeCategory, GetAgeCategoryDTO>();
            CreateMap<AgeCategoryDTO, AgeCategory>(); 
        }
    }
}
