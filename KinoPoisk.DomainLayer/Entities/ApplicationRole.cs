﻿using KinoPoisk.DomainLayer.Intarfaces;
using Microsoft.AspNetCore.Identity;

namespace KinoPoisk.DomainLayer.Entities {
    public class ApplicationRole : IdentityRole<Guid>, IEntity {
        public ApplicationRole() : base() {
        }

        public virtual ICollection<ApplicationUserRole> UserRoles { get; set; }
    }
}
