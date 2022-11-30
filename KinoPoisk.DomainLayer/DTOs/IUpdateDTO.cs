namespace KinoPoisk.DomainLayer.DTOs {
    public interface IUpdateDTO<TTypeId> {
        public TTypeId Id { get; set; }

        public IEnumerable<string> ValidateData();
    }
}
