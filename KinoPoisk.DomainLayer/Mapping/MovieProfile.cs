using AutoMapper;
using KinoPoisk.DomainLayer.DTOs.MovieCreatorDTOs;
using KinoPoisk.DomainLayer.DTOs.MovieDTOs;
using KinoPoisk.DomainLayer.Entities;

namespace KinoPoisk.DomainLayer.Mapping {
    public class MovieProfile : Profile{
        public MovieProfile() {
            CreateMap<MovieDTO, Movie>();
            CreateMap<Movie, GetMovieDTO>()
                .ForMember(x => x.Creators, c => c.MapFrom(m => m.CreatorsMovies));

            CreateMap<RatingDTO, Rating>();
            CreateMap<Rating, GetRatingDTO>();

            CreateMap<CreatorMovie, GetCreatorDTO>()
                .ForMember(x => x.Id, c => c.MapFrom(m => m.Creator.Id))
                .ForMember(x => x.DateOfBirth, c => c.MapFrom(m => m.Creator.DateOfBirth))
                .ForMember(x => x.FirstName, c => c.MapFrom(m => m.Creator.FirstName))
                .ForMember(x => x.LastName, c => c.MapFrom(m => m.Creator.LastName))
                .ForMember(x => x.Patronymic, c => c.MapFrom(m => m.Creator.Patronymic));

            CreateMap<Movie, GetMovieForDashBoardDto>()
                .ForMember(x => x.ImagePath, c => c.MapFrom(m => m.Contents.SingleOrDefault(x => x.Type == ContentType.Poster).Path));
        }
    }
}
