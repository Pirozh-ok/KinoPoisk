namespace KinoPoisk.DomainLayer.DTOs.AgeCategoryDTO {
    public class GetAgeCategoryDTO {
        public Guid Id { get; set; } = Guid.Empty;
        public string Value { get; set; }
        public uint MinAge { get; set; }
    }
}
