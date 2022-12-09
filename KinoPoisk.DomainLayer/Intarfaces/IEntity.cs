namespace KinoPoisk.DomainLayer.Intarfaces {
    public interface IEntity<TTypeId> {
        public TTypeId Id { get; set; }
    }
}
