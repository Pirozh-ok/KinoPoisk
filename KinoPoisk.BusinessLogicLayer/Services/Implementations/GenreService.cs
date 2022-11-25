using KinoPoisk.BusinessLogicLayer.DTOs;
using KinoPoisk.BusinessLogicLayer.DTOs.GenreDTOs;
using KinoPoisk.BusinessLogicLayer.Services.Interfaces;
using KinoPoisk.DataAccess;
using KinoPoisk.DomainLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace KinoPoisk.BusinessLogicLayer.Services.Implementations {
    public class GenreService : IGenreService {
        private readonly ApplicationDbContext _context; 

        public GenreService(ApplicationDbContext context) {
            _context = context;
        }

        public async Task CreateAsync(IUpdateOrCreateDto createDto) {
            var dto = createDto as CreateUpdateGenreDTO;

            await _context.Genres.AddAsync(
                new Genre {
                    Name = dto.Name,
                }); 

            _context.SaveChanges();
        }

        public async Task DeleteAsync(Guid id) {
            var genre = await _context.Genres
                .SingleOrDefaultAsync(x => x.Id == id);
            _context.Genres.Remove(genre);
            await _context.SaveChangesAsync(); 
        }

        public async Task<IEnumerable<IGetDto<Guid>>> GetAllAsync() {
            var dtoList = new List<GetGenreDTO>();
            var genres = await _context.Genres
                .AsNoTracking()
                .ToListAsync(); 

            foreach(var genre in genres) {
                dtoList.Add(
                    new GetGenreDTO {
                        Id = genre.Id,
                        Name = genre.Name,
                    });  
            }
            
            return dtoList;
        }

        public async Task<IGetDto<Guid>> GetByIdAsync(Guid Id) {
            var genre =  await _context.Genres.SingleOrDefaultAsync(x => x.Id == Id);
            return new GetGenreDTO() {
                Id = genre.Id,
                Name = genre.Name
            }; 
        }

        public async Task UpdateAsync(Guid Id, IUpdateOrCreateDto updateDto) {
            var dto = updateDto as CreateUpdateGenreDTO; 

            var genre = await _context.Genres
                 .SingleOrDefaultAsync(x => x.Id == Id);

            genre.Name = dto.Name;
            _context.SaveChangesAsync(); 
        }
    }
}
