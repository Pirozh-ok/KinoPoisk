using KinoPoisk.DomainLayer.Resources;

namespace KinoPoisk.DomainLayer.DTOs.CountryDTO {
    public class CountryDTO : BaseEntityDto<Guid> {
        public string Name { get; set; }
    }
}
