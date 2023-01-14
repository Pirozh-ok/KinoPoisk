using AutoMapper;
using KinoPoisk.DomainLayer.DTOs.ContentDTOs;
using KinoPoisk.DomainLayer.Entities;

namespace KinoPoisk.DomainLayer.Mapping {
    public class ContentProfile : Profile {
        public ContentProfile() {
            CreateMap<ContentDTO, Content>();
            CreateMap<GetContentDTO, Content>(); 
        }
    }
}
