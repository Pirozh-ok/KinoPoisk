using KinoPoisk.DataAccessLayer;
using KinoPoisk.DomainLayer.Resources;

namespace KinoPoisk.DomainLayer.DTOs.CountryDTO
{
    public class CreateCountryDTO : IValidate {
        public string Name { get; set; }

        public IEnumerable<string> ValidateData() {
            var errors = new List<string>();

            if (string.IsNullOrEmpty(Name) || Name.Length < 3) {
                errors.Add(CountryResource.NameLessMinLen);
            }

            if (Name.Length > Constants.MaxLenOfName) {
                errors.Add(CountryResource.NameExceedsMaxLen);
            }

            return errors;
        }
    }
}
