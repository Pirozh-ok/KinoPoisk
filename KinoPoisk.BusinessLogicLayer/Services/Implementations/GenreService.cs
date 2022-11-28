using KinoPoisk.DataAccessLayer;
using KinoPoisk.DomainLayer;
using KinoPoisk.DomainLayer.DTOs;
using KinoPoisk.DomainLayer.DTOs.GenreDTOs;
using KinoPoisk.DomainLayer.Entities;
using KinoPoisk.DomainLayer.Interfaces.Services;
using Microsoft.EntityFrameworkCore;

namespace KinoPoisk.BusinessLogicLayer.Services.Implementations
{
    public class GenreService : IGenreService {
        private readonly ApplicationDbContext _context; 

        public GenreService(ApplicationDbContext context) {
            _context = context;
        }

        public async Task<Result> CreateAsync(ICreateDTO createDto) {
            var dto = createDto as UpdateGenreDTO<Guid>;
            var errors = createDto.ValidateData(); 

            if(errors.Count() > 0) {
                return new ErrorResult(errors);
            }

            await _context.Genres.AddAsync(
                new Genre {
                    Name = dto.Name,
                }); 

            await _context.SaveChangesAsync();
            return new SuccessResult<string>("Genre is created");
        }

        public async Task<Result> DeleteAsync(Guid id) {
            var genre = await _context.Genres
                .SingleOrDefaultAsync(x => x.Id == id);

            if(genre is null) {
                return new ErrorResult(new List<string> { "Genre no found" }); 
            }

            _context.Genres.Remove(genre);
            await _context.SaveChangesAsync();
            return new SuccessResult<string>("Genre is deleted");
        }

        public async Task<Result> GetAllAsync() {
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
            
            return new SuccessResult<IEnumerable<GetGenreDTO>>(dtoList);
        }

        public async Task<Result> GetByIdAsync(Guid Id) {
            var genre = await _context.Genres.SingleOrDefaultAsync(x => x.Id == Id);

            return new SuccessResult<GetGenreDTO>(
                new GetGenreDTO() {
                    Id = genre.Id,
                    Name = genre.Name
                });
        }

        public async Task<Result> UpdateAsync(IUpdateDTO<Guid> updateDto) {
            var dto = updateDto as UpdateGenreDTO<Guid>;
            var errors = dto.ValidateData(); 

            if (errors.Count() > 0) {
                return new ErrorResult(errors); 
            }

            var genre = await _context.Genres
                 .SingleOrDefaultAsync(x => x.Id == dto.Id);

            genre.Name = dto.Name;
            await _context.SaveChangesAsync();
            return new SuccessResult<string>("Genre updated"); 
        }
    }
}
