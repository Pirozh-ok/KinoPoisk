using KinoPoisk.BusinessLogicLayer.DTOs;
using KinoPoisk.BusinessLogicLayer.DTOs.CountryDTOs;
using KinoPoisk.BusinessLogicLayer.Services.Interfaces;
using KinoPoisk.DataAccessLayer;
using KinoPoisk.DomainLayer.Entities;

namespace KinoPoisk.BusinessLogicLayer.Services.Implementations {
    public class CountryService : ICountryService {
        private readonly ApplicationDbContext _context;

        public CountryService(ApplicationDbContext context) {
            _context = context;
        }

        public async Task CreateAsync(IUpdateOrCreateDto createDto) {
            var dto = createDto as CreateOrUpdateCountryDTO;

            await _context.Countries.AddAsync(
                new Country() {
                    Name = dto.Name
                });

            await _context.SaveChangesAsync();
        }

        public Task DeleteAsync(Guid id) {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<IGetDto<Guid>>> GetAllAsync() {
            throw new NotImplementedException();
        }

        public Task<IGetDto<Guid>> GetByIdAsync(Guid Id) {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Guid id, IUpdateOrCreateDto updateDto) {
            throw new NotImplementedException();
        }
    }
}
