namespace KinoPoisk.DomainLayer.DTOs.AgeCategoryDTO {
    public class AgeCategoryDTO : BaseEntityDto<Guid>{
        public string Value { get; set; }
        public uint MinAge { get; set; }
    }
}
