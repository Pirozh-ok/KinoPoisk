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

        public virtual ICollection<GetCountryDTO> Countries { get; set; }
        public virtual ICollection<GetAgeCategoryDTO> AgeCategories { get; set; }
        public virtual ICollection<GetGenreDTO> Genres { get; set; }
        public virtual ICollection<GetAwardDTO> Awards { get; set; }
        public virtual ICollection<GetCreatorDTO> Creators { get; set; }
        public virtual ICollection<GetContentDTO> Contents { get; set; }
        public virtual ICollection<GetRatingDTO> Ratings { get; set; }
    }
}
