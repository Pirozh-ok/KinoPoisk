﻿namespace KinoPoisk.DomainLayer.DTOs.MovieCreatorDTOs {
    public class CreatorDTO : BaseEntityDto<Guid> {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Patronymic { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
