﻿namespace KinoPoisk.DomainLayer.Entities {
    public class Genre {
        public Genre() {
            Movies = new HashSet<Movie>();
        }

        public Guid Id { get; set; } = Guid.Empty;
        public string Name { get; set; }

        public virtual ICollection<Movie> Movies { get; set; }
    }
}
