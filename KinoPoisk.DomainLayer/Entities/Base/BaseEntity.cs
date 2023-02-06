using KinoPoisk.DomainLayer.Intarfaces;

namespace KinoPoisk.DomainLayer.Entities.Base {
    public abstract class BaseEntity<TKey> : IBaseEntity<TKey>
        where TKey : notnull, IEquatable<TKey> {
        public TKey Id { get; set; } = default!;
    }
}
