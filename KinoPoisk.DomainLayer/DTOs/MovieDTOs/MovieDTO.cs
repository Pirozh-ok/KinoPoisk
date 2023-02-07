namespace KinoPoisk.DomainLayer.DTOs.MovieDTOs {
    public class MovieDTO : BaseEntityDto<Guid> {
        public string Title { get; set; }
        public string Description { get; set; }
        public uint DurationInMinutes { get; set; }
        public decimal BudgetInDollars { get; set; }
        public decimal WorldFeesInDollars { get; set; }
        public DateTime PremiereDate { get; set; }

        public IEnumerable<Guid> CountriesIds { get; set; } = new List<Guid>();
        public IEnumerable<Guid> GenresIds { get; set; } = new List<Guid>(); 
        public IEnumerable<Guid> AgeCategoriesIds { get; set; } = new List<Guid>(); 
    }
}
