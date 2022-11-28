//using KinoPoisk.DomainLayer.DTOs;
//using KinoPoisk.DataAccessLayer;
//using KinoPoisk.DomainLayer.Entities;
//using KinoPoisk.DomainLayer.DTOs.GenreDTOs;
//using KinoPoisk.DomainLayer.Interfaces.Services;
//using KinoPoisk.DomainLayer.DTOs.CountryDTOs;

//namespace KinoPoisk.BusinessLogicLayer.Services.Implementations
//{
//    public class CountryService : ICountryService {
//        private readonly ApplicationDbContext _context;

//        public CountryService(ApplicationDbContext context) {
//            _context = context;
//        }

//        public async Task CreateAsync(ICreateDTO createDto) {
//            var dto = createDto as CreateGenreDto;

//            await _context.Countries.AddAsync(
//                new Country() {
//                    Name = dto.Name
//                });

//            await _context.SaveChangesAsync();
//        }

//        public Task DeleteAsync(Guid id) {
//            throw new NotImplementedException();
//        }

//        public Task<IEnumerable<GetCountryDTO>> GetAllAsync() {
//            throw new NotImplementedException();
//        }

//        public Task<GetCountryDTO> GetByIdAsync(Guid Id) {
//            throw new NotImplementedException();
//        }

//        public Task UpdateAsync(IUpdateDTO<Guid> updateDto) {
//            throw new NotImplementedException();
//        }
//    }
//}
