using KinoPoisk.DomainLayer.Resources;

namespace KinoPoisk.DomainLayer.DTOs.UserDTO {
    public class UpdateUserDTO : IUpdateDTO<Guid> {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? Patronymic { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public Guid CountryId { get; set; }

        public IEnumerable<string> ValidateData() {
            var errors = new List<string>();

            if (string.IsNullOrEmpty(UserName) || UserName.Length < 2) {
                errors.Add(UserResource.UserNameLessMinLen);
            }

            if (UserName.Length > 50) {
                errors.Add(UserResource.UserNameExceedsMaxLen);
            }

            if (string.IsNullOrEmpty(FirstName) || FirstName.Length < 2) {
                errors.Add(UserResource.FirstNameLessMinLen);
            }

            if (FirstName.Length > 50) {
                errors.Add(UserResource.FirstNameExceedsMaxLen);
            }

            if (string.IsNullOrEmpty(LastName) || LastName.Length < 2) {
                errors.Add(UserResource.LastNameLessMinLen);
            }

            if (LastName.Length > 50) {
                errors.Add(UserResource.LastNameExceedsMaxLen);
            }

            if (Patronymic is not null || Patronymic.Length < 2) {
                errors.Add(UserResource.PatronymicLessMinLen);
            }

            if (Patronymic is not null || Patronymic.Length > 50) {
                errors.Add(UserResource.PatronymicExceedsMaxLen);
            }

            if (string.IsNullOrEmpty(Email) || Email.Length < 2) {
                errors.Add(UserResource.EmailLessMinLen);
            }

            if (Email.Length > 50) {
                errors.Add(UserResource.EmailExceedsMaxLen);
            }

            if (string.IsNullOrEmpty(Password) || Password.Length < 6) {
                errors.Add(UserResource.PasswordLessMinLen);
            }

            if (string.IsNullOrEmpty(Password) || Password.Length > 30) {
                errors.Add(UserResource.PasswordExceedsMaxLen);
            }

            if (DateOfBirth < DateTime.UtcNow.AddYears(-100) || DateOfBirth > DateTime.UtcNow) {
                errors.Add(UserResource.IncorrectDateOfBirth);
            }

            return errors;
        }
    }
}
