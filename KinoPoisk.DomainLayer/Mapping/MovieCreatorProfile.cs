using AutoMapper;
using KinoPoisk.DomainLayer.DTOs.MovieCreatorDTOs;
using KinoPoisk.DomainLayer.Entities; 

namespace KinoPoisk.DomainLayer.Mapping {
    public class MovieCreatorProfile : Profile {
        public MovieCreatorProfile() {
            CreateMap<MovieCreatorDTO, Creator>();
            CreateMap<Creator, GetMovieCreatorDTO>();
        }
    }
}
