using AutoMapper;
using KinoPoisk.DomainLayer.DTOs.AwardDTOs;
using KinoPoisk.DomainLayer.Entities;

namespace KinoPoisk.DomainLayer.Mapping {
    public class AwardProfile : Profile{
        public AwardProfile() {
            CreateMap<Award, GetAwardDTO>();
            CreateMap<AwardDTO, Award>(); 
        }
    }
}
