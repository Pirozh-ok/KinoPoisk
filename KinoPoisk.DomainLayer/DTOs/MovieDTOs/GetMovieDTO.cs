using KinoPoisk.DomainLayer.DTOs.AgeCategoryDTO;
using KinoPoisk.DomainLayer.DTOs.AwardDTOs;
using KinoPoisk.DomainLayer.DTOs.ContentDTOs;
using KinoPoisk.DomainLayer.DTOs.CountryDTO;
using KinoPoisk.DomainLayer.DTOs.GenreDTO;
using KinoPoisk.DomainLayer.DTOs.MovieCreatorDTOs;

namespace KinoPoisk.DomainLayer.DTOs.MovieDTOs {
    public class GetMovieDTO {
        public Guid Id { get; set; } = Guid.Empty;
        public string Title { get; set; }
        public string Description { get; set; }
        public uint DurationInMinutes { get; set; }
        public decimal BudgetInDollars { get; set; }
        public decimal WorldFeesInDollars { get; set; }
        public DateTime PremiereDate { get; set; }

        public IEnumerable<GetCountryDTO> Countries { get; set; }
        public IEnumerable<GetAgeCategoryDTO> AgeCategories { get; set; }
        public IEnumerable<GetGenreDTO> Genres { get; set; }
        public IEnumerable<GetAwardDTO> Awards { get; set; }
        public IEnumerable<GetCreatorDTO> Creators { get; set; }
        public IEnumerable<GetContentDTO> Contents { get; set; }
        public double? AvgRating { get; set; }
    }
}
