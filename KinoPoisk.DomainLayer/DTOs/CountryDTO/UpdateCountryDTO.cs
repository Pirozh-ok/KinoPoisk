using KinoPoisk.DomainLayer.Resources;

namespace KinoPoisk.DomainLayer.DTOs.CountryDTO {
    public class UpdateCountryDTO : IUpdateDTO<Guid>{
        public Guid Id { get; set; }
        public string Name { get; set; }

        public IEnumerable<string> ValidateData() {
            var errors = new List<string>();

            //if (Id is null) {
            //    errors.Add(CountryResource.InvalidId);
            //}

            if (string.IsNullOrEmpty(Name) || Name.Length < 3) {
                errors.Add(CountryResource.NameLessMinLen);
            }

            if (Name.Length > 50) {
                errors.Add(CountryResource.NameExceedsMaxLen);
            }

            return errors;
        }
    }
}
