using AutoMapper;
using KinoPoisk.DomainLayer.DTOs.MovieCreatorDTOs;
using KinoPoisk.DomainLayer.Entities; 

namespace KinoPoisk.DomainLayer.Mapping {
    public class CreatorProfile : Profile {
        public CreatorProfile() {
            CreateMap<CreatorDTO, Creator>();
            CreateMap<Creator, GetCreatorDTO>();
        }
    }
}
