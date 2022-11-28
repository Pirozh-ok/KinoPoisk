namespace KinoPoisk.DataAccessLayer.Repositories {
    public class GenreRepository : GenericRepository<Genre, Guid> {
        public GenreRepository(ApplicationDbContext context) : base(context) {
        }
    }
}
