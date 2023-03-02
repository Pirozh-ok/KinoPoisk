using KinoPoisk.DomainLayer.Entities.Base;

namespace KinoPoisk.DomainLayer.Entities {
    public class Movie : BaseEntity<Guid> {
        public Movie() {
            Countries = new HashSet<Country>();
            AgeCategories = new HashSet<AgeCategory>();
            Genres = new HashSet<Genre>();
            Awards = new HashSet<Award>();
            CreatorsMovies = new HashSet<CreatorMovie>();
            Contents = new HashSet<Content>();
            Ratings = new HashSet<Rating>();
        }

        public string Title { get; set; }
        public string Description { get; set; }
        public uint DurationInMinutes { get; set; }
        public decimal BudgetInDollars { get; set; }
        public decimal WorldFeesInDollars { get; set; }
        public DateTime PremiereDate { get; set; }

        public virtual ICollection<Country> Countries { get; set; }
        public virtual ICollection<AgeCategory> AgeCategories { get; set; }
        public virtual ICollection<Genre> Genres { get; set; }
        public virtual ICollection<Award> Awards { get; set; }
        public virtual ICollection<CreatorMovie> CreatorsMovies { get; set; }
        public virtual ICollection<Content> Contents { get; set; }
        public virtual ICollection<Rating?> Ratings { get; set; }
    }
}
