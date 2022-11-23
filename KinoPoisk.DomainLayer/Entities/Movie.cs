namespace KinoPoisk.DomainLayer.Entities
{
    public class Movie
    {
        public Movie()
        {
            Id = Guid.Empty; 
            Countries = new HashSet<Country>();
            AgeCategories = new HashSet<AgeCategory>();
            Genres = new HashSet<Genre>();
            Awards = new HashSet<Award>();
            Creator_Movies = new HashSet<Creator_Movie>();
            Content = new HashSet<Content>();
            Ratings = new HashSet<Rating>(); 
        }

        public Guid Id { get; set; } = Guid.Empty;
        public string Title { get; set; }
        public string Description { get; set; }
        public uint DurationInMinutes { get; set; }
        public decimal BudgetInDollars { get; set; }
        public decimal WorldFeesInDollars { get; set; }
        public DateTime PremiereDate { get; set; }

        public ICollection<Country> Countries { get; set; }
        public ICollection<AgeCategory> AgeCategories { get; set; }
        public ICollection<Genre> Genres { get; set; }
        public ICollection<Award> Awards { get; set; }
        public ICollection<Creator_Movie> Creator_Movies { get; set; }
        public ICollection<Content> Content { get; set; }
        public ICollection<Rating> Ratings { get; set; }
    }
}
