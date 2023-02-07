namespace KinoPoisk.DomainLayer.DTOs {
    public class BaseEntityDto<TKey>
        where TKey: IEquatable<TKey> {
        public TKey Id { get; set; }
    }
}
