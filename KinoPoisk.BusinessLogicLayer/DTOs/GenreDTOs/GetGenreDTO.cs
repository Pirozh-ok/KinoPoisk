namespace KinoPoisk.BusinessLogicLayer.DTOs.GenreDTOs {
    public class GetGenreDTO : IGetDto<Guid> {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
