using KinoPoisk.DomainLayer.Entities;
using Microsoft.AspNetCore.Identity;

namespace KinoPoisk.DataAccessLayer {
    public class SeedData {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;

        public SeedData(UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager) {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task SeedRoles() {
            if (!_roleManager.RoleExistsAsync(Constants.NameRoleAdmin).Result) {
                await _roleManager.CreateAsync(
                    new ApplicationRole() {
                        Name = Constants.NameRoleAdmin
                    });
            }

            if (!_roleManager.RoleExistsAsync(Constants.NameRoleUser).Result) {
                await _roleManager.CreateAsync(
                    new ApplicationRole() {
                        Name = Constants.NameRoleUser
                    });
            }
        }

        public async Task SeedUsers() {
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

                var result = await _userManager.CreateAsync(user, "password");

                if (result.Succeeded) {
                    await _userManager.AddToRoleAsync(user, Constants.NameRoleUser);
                    await _userManager.AddToRoleAsync(user, Constants.NameRoleAdmin);
                }
            }
        }
    }
}
