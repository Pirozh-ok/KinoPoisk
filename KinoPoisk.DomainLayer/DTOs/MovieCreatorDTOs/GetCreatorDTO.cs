using KinoPoisk.DomainLayer.DTOs.MovieRoleDTOs;

namespace KinoPoisk.DomainLayer.DTOs.MovieCreatorDTOs {
    public class GetCreatorDTO {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Patronymic { get; set; }
        public DateTime DateOfBirth { get; set; }
        public IEnumerable<GetMovieRoleDTO> Roles { get; set; }
    }
}
