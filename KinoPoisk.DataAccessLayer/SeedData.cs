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
            if (!_roleManager.RoleExistsAsync(Constants.NameRoleAdmin).Result) {
                _roleManager.CreateAsync(
                    new ApplicationRole() {
                        Name = Constants.NameRoleAdmin
                    });
            }

            if (!_roleManager.RoleExistsAsync(Constants.NameRoleUser).Result) {
                _roleManager.CreateAsync(
                    new ApplicationRole() {
                        Name = Constants.NameRoleUser
                    });
            }
        }

        private void SeedUsers() {
            var adminEmail = "ivan.vorotnikov.2002@mail.ru"; 
            if(_userManager.FindByEmailAsync(adminEmail).Result is null) {
                var user = new ApplicationUser() {
                    UserName = "Admin",
                    Email = adminEmail,
                    FirstName = "Ivan",
                    LastName = "Vorotnikov",
                    Patronymic = "Sergeevich",
                    DateOfBirth = new DateTime(2002, 1, 20),
                    DateOfRegistration = DateTime.Now,
                };

                var result = _userManager.CreateAsync(user, "password");

                if (result.Result.Succeeded) {
                    _userManager.AddToRoleAsync(user, Constants.NameRoleUser); 
                }
            }
        }
    }
}
