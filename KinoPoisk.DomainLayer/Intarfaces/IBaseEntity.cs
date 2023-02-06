namespace KinoPoisk.DomainLayer.Intarfaces {
    public interface IBaseEntity<TKey> {
        public TKey Id { get; set; }
    }
}
