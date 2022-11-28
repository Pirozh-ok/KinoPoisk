using KinoPoisk.DomainLayer.DTOs.CountryDTOs;
using KinoPoisk.DomainLayer.DTOs.GenreDTOs;

namespace KinoPoisk.DomainLayer.Interfaces.Services
{
    public interface ICountryService : IService<Guid, GetCountryDTO>
    {
    }
}
