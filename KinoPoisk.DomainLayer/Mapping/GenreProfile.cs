using AutoMapper;
using KinoPoisk.DomainLayer.DTOs.GenreDTO;
using KinoPoisk.DomainLayer.Entities;

namespace KinoPoisk.DomainLayer.Mapping {
    public class GenreProfile : Profile {
        public GenreProfile() {
            CreateMap<CreateGenreDto, Genre>();
            CreateMap<UpdateGenreDTO, Genre>();
            CreateMap<Genre, GetGenreDTO>(); 
        }
    }
}
