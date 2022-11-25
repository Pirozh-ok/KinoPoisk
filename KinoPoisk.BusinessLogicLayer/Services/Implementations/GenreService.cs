using KinoPoisk.BusinessLogicLayer.DTOs;
using KinoPoisk.BusinessLogicLayer.DTOs.GenreDTOs;
using KinoPoisk.BusinessLogicLayer.Services.Interfaces;
using KinoPoisk.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace KinoPoisk.BusinessLogicLayer.Services.Implementations {
    public class GenreService : IService<Guid> {
        private readonly ApplicationDbContext _context; 

        public GenreService(ApplicationDbContext context) {
            _context = context;
        }

        public Task CreateAsync(IUpdateOrCreateDto createDto) {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Guid id) {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<IGetDto<Guid>>> GetAllAsync() {
            throw new NotImplementedException();
            //return await _context.Genres.ToListAsync();
        }

        public async Task<IGetDto<Guid>> GetByIdAsync(Guid Id) {
            var genre =  await _context.Genres.SingleOrDefaultAsync(x => x.Id == Id);
            return new GetGenreDTO() {
                Id = genre.Id,
                Name = genre.Name
            }; 
        }

        public Task UpdateAsync(IUpdateOrCreateDto updateDto) {
            throw new NotImplementedException();
        }
    }
}
