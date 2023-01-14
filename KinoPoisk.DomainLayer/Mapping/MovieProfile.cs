using AutoMapper;
using KinoPoisk.DomainLayer.DTOs.MovieDTOs;
using KinoPoisk.DomainLayer.Entities;

namespace KinoPoisk.DomainLayer.Mapping {
    public class MovieProfile : Profile{
        public MovieProfile() {
            CreateMap<MovieDTO, Movie>();
            CreateMap<Movie, GetMovieDTO>();
        }
    }
}
