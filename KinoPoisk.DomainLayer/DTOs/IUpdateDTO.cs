namespace KinoPoisk.DomainLayer.DTOs {
    public interface IUpdateDTO<TTypeId> : IValidate {
        public TTypeId Id { get; set; }
    }
}
