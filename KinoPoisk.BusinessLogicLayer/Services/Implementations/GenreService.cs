using KinoPoisk.DataAccessLayer;
using KinoPoisk.DomainLayer;
using KinoPoisk.DomainLayer.DTOs;
using KinoPoisk.DomainLayer.DTOs.GenreDTOs;
using KinoPoisk.DomainLayer.Entities;
using KinoPoisk.DomainLayer.Interfaces.Services;
using KinoPoisk.DataAccessLayer.Repositories;

namespace KinoPoisk.BusinessLogicLayer.Services.Implementations
{
    public class GenreService : IGenreService {
        private readonly GenreRepository _repository; 

        public GenreService(GenreRepository repository) {
            _repository = repository;
        }

        public async Task<Result> CreateAsync(ICreateDTO createDto) {
            var dto = createDto as UpdateGenreDTO<Guid>;

            if(dto is null) {
                new ErrorResult(new List<string> { "Argument null" });
            }

            var errors = createDto.ValidateData(); 

            if(errors.Count() > 0) {
                return new ErrorResult(errors);
            }

            await _repository.CreateAsync(
                new Genre {
                    Name = dto.Name,
                }); 

            return new SuccessResult<string>("Genre is created");
        }

        public async Task<Result> DeleteAsync(Guid id) {
            var genre = await _repository.GetByIdAsync(id);

            if(genre is null) {
                return new ErrorResult(new List<string> { "Genre no found" }); 
            }

            await _repository.DeleteAsync(genre);
            return new SuccessResult<string>("Genre is deleted");
        }

        public async Task<Result> GetAllAsync() {
            var dtoList = new List<GetGenreDTO>();
            var genres = await _repository.GetAllAsync(); 

            foreach(var genre in genres) {
                dtoList.Add(
                    new GetGenreDTO {
                        Id = genre.Id,
                        Name = genre.Name,
                    });  
            }
            
            return new SuccessResult<IEnumerable<GetGenreDTO>>(dtoList);
        }

        public async Task<Result> GetByIdAsync(Guid id) {
            var genre = await _repository.GetByIdAsync(id);

            return new SuccessResult<GetGenreDTO>(
                new GetGenreDTO() {
                    Id = genre.Id,
                    Name = genre.Name
                });
        }

        public async Task<Result> UpdateAsync(IUpdateDTO<Guid> updateDto) {
            var dto = updateDto as UpdateGenreDTO<Guid>;

            if (dto is null) {
                new ErrorResult(new List<string> { "Argument null" });
            }

            var errors = dto.ValidateData(); 

            if (errors.Count() > 0) {
                return new ErrorResult(errors); 
            }

            var genre = await _repository.GetByIdAsync(dto.Id);

            if(genre is null) {
                return new ErrorResult(new List<string> { "Genre not found"});
            }

            genre.Name = dto.Name;
            await _repository.UpdateAsync(genre); 
            return new SuccessResult<string>("Genre updated"); 
        }
    }
}
