﻿namespace KinoPoisk.DomainLayer.DTOs.MovieDTOs {
    public class RatingDTO {
        public Guid UserId { get; set; }
        public Guid MovieId { get; set; }
        public string Comment { get; set; }
        public uint MovieRating { get; set; }
    }
}
