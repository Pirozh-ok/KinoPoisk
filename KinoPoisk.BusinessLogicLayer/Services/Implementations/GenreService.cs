using KinoPoisk.DomainLayer;
using KinoPoisk.DomainLayer.DTOs;
using KinoPoisk.DomainLayer.Entities;
using KinoPoisk.DomainLayer.Intarfaces.Services;
using KinoPoisk.DomainLayer.DTOs.GenreDTO;

namespace KinoPoisk.BusinessLogicLayer.Services.Implementations {
    public class GenreService : IGenreService {
        private readonly IUnitOfWork _unitOfWork; 

        public GenreService(IUnitOfWork unitOfWork) {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> CreateAsync(ICreateDTO createDto) {
            var dto = createDto as CreateGenreDto;

            if(dto is null) {
                return new ErrorResult(new List<string> { "Argument null" });
            }

            var errors = createDto.ValidateData(); 

            if(errors.Count() > 0) {
                return new ErrorResult(errors);
            }

            _unitOfWork.GetRepository<Genre>().Create(
                new Genre {
                    Name = dto.Name,
                });

            await _unitOfWork.CommitAsync(); 

            return new SuccessResult<string>("Genre is created");
        }

        public async Task<Result> DeleteAsync(Guid id) {
            var genre = _unitOfWork.GetRepository<Genre>().GetById(id);

            if(genre is null) {
                return new ErrorResult(new List<string> { "Genre no found" }); 
            }

            _unitOfWork.GetRepository<Genre>().Delete(genre);
            await _unitOfWork.CommitAsync(); 
            return new SuccessResult<string>("Genre is deleted");
        }

        public async Task<Result> GetAllAsync() {
            var dtoList = new List<GetGenreDTO>();
            var genres = _unitOfWork.GetRepository<Genre>().GetAll(); 

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
            var genre = _unitOfWork.GetRepository<Genre>().GetById(id);

            return genre is null ?
                new ErrorResult(new List<string>() { "Genre not found!" }) :
                new SuccessResult<GetGenreDTO>(
                    new GetGenreDTO() {
                        Id = genre.Id,
                        Name = genre.Name
                    });
        }

        public async Task<Result> UpdateAsync(IUpdateDTO<Guid> updateDto) {
            var dto = updateDto as UpdateGenreDTO;

            if (dto is null) {
                new ErrorResult(new List<string> { "Argument null" });
            }

            var errors = dto.ValidateData(); 

            if (errors.Count() > 0) {
                return new ErrorResult(errors); 
            }

            var genre = _unitOfWork.GetRepository<Genre>().GetById(dto.Id);

            if(genre is null) {
                return new ErrorResult(new List<string> { "Genre not found"});
            }

            genre.Name = dto.Name;
            _unitOfWork.GetRepository<Genre>().Update(genre);
            await _unitOfWork.CommitAsync(); 
            return new SuccessResult<string>("Genre updated"); 
        }
    }
}
