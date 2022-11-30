using AutoMapper;
using KinoPoisk.DomainLayer.DTOs.CountryDTO;
using KinoPoisk.DomainLayer.DTOs.GenreDTO;
using KinoPoisk.DomainLayer.Entities;

namespace KinoPoisk.DomainLayer.Mapping {
    public class CountryProfile : Profile {
        public CountryProfile() {
            CreateMap<CreateCountryDTO, Country>();
            CreateMap<UpdateCountryDTO, Country>();
            CreateMap<Country, GetCountryDTO>();
        }
    }
}
