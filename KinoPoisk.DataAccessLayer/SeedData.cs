using KinoPoisk.DomainLayer.Entities;
using Microsoft.AspNetCore.Identity;

namespace KinoPoisk.DataAccessLayer {
    public class SeedData {
        public readonly UserManager<ApplicationUser> _userManager;
        public readonly RoleManager<ApplicationRole> _roleManager;

        public SeedData(UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager) {
            _userManager = userManager;
            _roleManager = roleManager;

            SeedRoles();
            SeedUsers();
        }

        private void SeedRoles() {
            if (!_roleManager.RoleExistsAsync("Admin").Result) {
                _roleManager.CreateAsync(
                    new ApplicationRole() {
                        Name = "Admin"
                    });
            }

            if (!_roleManager.RoleExistsAsync("User").Result) {
                _roleManager.CreateAsync(
                    new ApplicationRole() {
                        Name = "User"
                    });
            }
        }

        private void SeedUsers() {
            if(_userManager.FindByNameAsync("Admin").Result is null) {
                var user = new ApplicationUser() {
                    UserName = "Admin",
                    Email = "applicationadmin@gmail.com",
                    FirstName = "Ivan",
                    LastName = "Vorotnikov",
                    Patronymic = "Sergeevich",
                    DateOfBirth = new DateTime(2002, 1, 20),
                    DateOfRegistration = DateTime.Now,
                    CountryId = Guid.Parse("3823CDD1-7D87-4F58-AFF6-5795B75E0BB0"),
                    PhoneNumber = "" 
                };

                var result = _userManager.CreateAsync(user, "adminsecretkey");

                if (result.Result.Succeeded) {
                    _userManager.AddToRoleAsync(user, "Admin"); 
                }
            }
        }
    }
}
