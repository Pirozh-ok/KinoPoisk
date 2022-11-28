namespace KinoPoisk.DomainLayer.DTOs.GenreDTOs
{
    public class UpdateGenreDTO<TTypeId> : IUpdateDTO<TTypeId>
    {
        public TTypeId Id { get; set; }
        public string Name { get; set; }

        public IEnumerable<string> ValidateData()
        {
            var errors = new List<string>();

            if (Id is null)
            {
                errors.Add("Invalid ID value!");
            }

            if (string.IsNullOrEmpty(Name) || Name.Length < 3)
            {
                errors.Add("Invalid name value. The minimum length of the genre name is 3");
            }

            if (Name.Length > 100)
            {
                errors.Add("Invalid name value. The length of the genre name should not exceed 100 characters");
            }

            return errors;
        }
    }
}
