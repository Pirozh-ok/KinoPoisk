using KinoPoisk.DomainLayer.Entities;
using Microsoft.AspNetCore.Identity;

namespace KinoPoisk.DataAccessLayer.Entities {
    public class ApplicationUserRole : IdentityUserRole<Guid> {
        public virtual ApplicationUser User { get; set; }
        public virtual ApplicationRole Role { get; set; }
    }
}
