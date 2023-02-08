using KinoPoisk.DomainLayer.Entities.Base;
using KinoPoisk.DomainLayer.Intarfaces;
using Microsoft.AspNetCore.Identity;

namespace KinoPoisk.DomainLayer.Entities {
    public class ApplicationRole : IdentityRole<Guid>, IBaseEntity<Guid> {
        public ApplicationRole() : base() {
        }

        public virtual ICollection<ApplicationUserRole> UserRoles { get; set; }
    }
}
