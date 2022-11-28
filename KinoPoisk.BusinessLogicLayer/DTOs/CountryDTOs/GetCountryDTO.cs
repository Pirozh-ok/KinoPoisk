namespace KinoPoisk.BusinessLogicLayer.DTOs.CountryDTOs {
    public class GetCountryDTO : IGetDto<Guid> {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
