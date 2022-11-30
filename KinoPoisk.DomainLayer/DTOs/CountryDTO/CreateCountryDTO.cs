namespace KinoPoisk.DomainLayer.DTOs.CountryDTO {
    public class CreateCountryDTO : ICreateDTO {
        public string Name { get; set; }

        public IEnumerable<string> ValidateData() {
            var errors = new List<string>();

            if (string.IsNullOrEmpty(Name) || Name.Length < 3) {
                errors.Add("Invalid name value. The minimum length of the country name is 3");
            }

            if (Name.Length > 50) {
                errors.Add("Invalid name value. The length of the country name should not exceed 50 characters");
            }

            return errors;
        }
    }
}
