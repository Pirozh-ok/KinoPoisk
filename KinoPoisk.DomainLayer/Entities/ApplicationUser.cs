using KinoPoisk.DomainLayer.Intarfaces;
using Microsoft.AspNetCore.Identity;

namespace KinoPoisk.DomainLayer.Entities {
    public class ApplicationUser : IdentityUser<Guid>, IEntity {
        public ApplicationUser() : base() {
            MovieRatings = new HashSet<Rating>();
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Patronymic { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime DateOfRegistration { get; set; }
        public Guid? CountryId { get; set; }
        public string? RefreshToken { get; set; }
        public DateTime? RefreshTokenExpiryDate { get; set; }

        public Country? Country { get; set; }
        public virtual ICollection<Rating> MovieRatings { get; set; }
        public virtual ICollection<ApplicationUserRole> UserRoles { get; set; }
    }
}
