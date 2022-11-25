using KinoPoisk.DataAccessLayer.Entities;
using KinoPoisk.DomainLayer.Entities;
using Microsoft.AspNetCore.Identity;

namespace KinoPoisk.DataAccess.Entities {
    public class ApplicationUserRole : IdentityUserRole<Guid> {
        public virtual ApplicationUser User { get; set; }
        public virtual ApplicationRole Role { get; set; }
    }
}
