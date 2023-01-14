using KinoPoisk.DomainLayer.Intarfaces;

namespace KinoPoisk.DomainLayer.Entities {
    public class Movie : IEntity<Guid> {
        public Movie() {
            Id = Guid.Empty;
            Countries = new HashSet<Country>();
            AgeCategories = new HashSet<AgeCategory>();
            Genres = new HashSet<Genre>();
            Awards = new HashSet<Award>();
            Creators_Movies = new HashSet<CreatorMovie>();
            Contents = new HashSet<Content>();
            Ratings = new HashSet<Rating>();
        }

        public Guid Id { get; set; } = Guid.Empty;
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
        public virtual ICollection<CreatorMovie> Creators_Movies { get; set; }
        public virtual ICollection<Content> Contents { get; set; }
        public virtual ICollection<Rating> Ratings { get; set; }
    }
}
