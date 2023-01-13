using AutoMapper;
using KinoPoisk.DomainLayer.DTOs.MovieRoleDTOs;
using KinoPoisk.DomainLayer.Entities;

namespace KinoPoisk.DomainLayer.Mapping {
    public class MovieRoleProfile : Profile {
        public MovieRoleProfile() {
            CreateMap<MovieRole, GetMovieRoleDTO>();
            CreateMap<MovieRoleDTO, MovieRole>();
        }
    }
}
