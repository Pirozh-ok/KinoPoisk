﻿using KinoPoisk.DomainLayer.Resources;

namespace KinoPoisk.DomainLayer.DTOs.GenreDTO {
    public class UpdateGenreDTO : IUpdateDTO<Guid> {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public IEnumerable<string> ValidateData() {
            var errors = new List<string>();

            //if (Id is null) {
            //    errors.Add(GenreResource.InvalidId);
            //}

            if (string.IsNullOrEmpty(Name) || Name.Length < 3) {
                errors.Add(GenreResource.NameLessMinLen);
            }

            if (Name.Length > 100) {
                errors.Add(GenreResource.NameExceedsMaxLen);
            }

            return errors;
        }
    }
}