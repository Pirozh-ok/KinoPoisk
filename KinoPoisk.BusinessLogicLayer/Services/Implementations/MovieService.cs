using AutoMapper;
using AutoMapper.QueryableExtensions;
using KinoPoisk.BusinessLogicLayer.Services.Base;
using KinoPoisk.DataAccessLayer;
using KinoPoisk.DomainLayer;
using KinoPoisk.DomainLayer.DTOs.MovieCreatorDTOs;
using KinoPoisk.DomainLayer.DTOs.MovieDTOs;
using KinoPoisk.DomainLayer.Entities;
using KinoPoisk.DomainLayer.Extensions;
using KinoPoisk.DomainLayer.Intarfaces.Services;
using KinoPoisk.DomainLayer.RequestParameterModels;
using KinoPoisk.DomainLayer.Resources;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace KinoPoisk.BusinessLogicLayer.Services.Implementations
{
    public class MovieService : BaseService<Movie, MovieDTO, Guid> {
        private readonly IHttpContextAccessor _accessor;
        public MovieService(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor accessor) : base(unitOfWork, mapper) {
            _accessor = accessor;
        }

        public async override Task<ServiceResult> CreateAsync(MovieDTO dto) {
            var errors = Validate(dto);

            if (errors.Count > 0) {
                return ServiceResult.Fail(errors);
            }

            dto.Id = Guid.Empty;
            var createObj = _mapper.Map<Movie>(dto);

            var countryRepository = _unitOfWork.GetRepository<Country>();
            var genreRepository = _unitOfWork.GetRepository<Genre>();
            var ageCategoryRepository = _unitOfWork.GetRepository<AgeCategory>();

            foreach(var id in dto.CountriesIds) {
                var country = countryRepository.GetById(id);
                
                if(country is not null) {
                    createObj.Countries.Add(country);
                }
            }

            foreach (var id in dto.GenresIds) {
                var genre = genreRepository.GetById(id);

                if (genre is not null) {
                    createObj.Genres.Add(genre);
                }
            }

            foreach (var id in dto.AgeCategoriesIds) {
                var ageCategory = ageCategoryRepository.GetById(id);

                if (ageCategory is not null) {
                    createObj.AgeCategories.Add(ageCategory);
                }
            }

            await _unitOfWork.GetRepository<Movie>().CreateAsync(createObj);
            await _unitOfWork.CommitAsync();

            return ServiceResult.Ok(GenericServiceResource.Created);
        }

        public async Task<ServiceResult> AddOrUpdateCreatorToMovie(AddCreatorToMovieDTO dto) {

            if(dto is null) {
                return ServiceResult.Fail(MovieResource.NullArgument);
            }

            var validateResult = await ValidateMovieAndCreatorIdsAsync(dto.MovieId, dto.CreatorId);

            if (validateResult.Failure) {
                return validateResult;
            }

            var obj = await _unitOfWork.GetRepository<CreatorMovie>()
                .GetByFilterInclude(x => x.CreatorId == dto.CreatorId && x.MovieId == dto.MovieId,
                x => x.Roles);
            var roles = new List<MovieRole>();

            foreach(var id in dto.Roles) {
                var role = _unitOfWork.GetRepository<MovieRole>().GetById(id);

                if (role is not null){
                    roles.Add(role);
                }
            }

            if (obj is null) {
                await _unitOfWork.GetRepository<CreatorMovie>().CreateAsync(
                    new CreatorMovie() {
                        CreatorId = dto.CreatorId,
                        MovieId = dto.MovieId,
                        Roles = roles
                    });
            }
            else {
                obj.Roles = roles;
                _unitOfWork.GetRepository<CreatorMovie>().Update(obj);
            }

            await _unitOfWork.CommitAsync();
            return ServiceResult.Ok();
        }

        public async Task<ServiceResult> RemoveCreatorFromMovie(Guid movieId, Guid creatorId) {
            var validateResult = await ValidateMovieAndCreatorIdsAsync(movieId, creatorId);

            if (validateResult.Failure) {
                return validateResult;
            }

            var obj = await _unitOfWork.GetRepository<CreatorMovie>()
                .GetByFilter(x => x.CreatorId == creatorId && x.MovieId == movieId);

            if(obj is null) {
                return ServiceResult.Fail(GenericServiceResource.NotFound);
            }

            _unitOfWork.GetRepository<CreatorMovie>().Delete(obj);
            return ServiceResult.Ok();
        }

        public async Task<ServiceResult> GetCreaterByMovieAsync(Guid movieId) {
            if(!await _unitOfWork.GetRepository<Movie>()
                .AnyAsync(x => x.Id == movieId)) {
                return ServiceResult.Fail(MovieResource.MovieNotFound);
            }

            var objs = await _unitOfWork.GetRepository<CreatorMovie>()
                .GetAllByFilter(x => x.MovieId == movieId)
                .ProjectTo<GetCreatorDTO>(_mapper.ConfigurationProvider)
                .ToListAsync();

            return ServiceResult.Ok(objs);
        }

        public async Task<ServiceResult> GetWithParameters(MovieRequestParameters parameters) =>
            ServiceResult.Ok( await _unitOfWork.GetRepository<Movie>()
                .GetAll()
                .ToPagedFilteredSortedListAsync(parameters));

        protected override List<string> Validate(MovieDTO dto) {
            var errors = new List<string>();

            if(dto is null) {
                errors.Add(MovieResource.NullArgument);
                return errors;
            }

            if(string.IsNullOrEmpty(dto.Title) || dto.Title.Length < Constants.MinLenOfName) {
                errors.Add(MovieResource.TitleLessMinLen);
            }

            if(dto.Title.Length > Constants.MaxLenOfTitleMovie) {
                errors.Add(MovieResource.TitleExceedsMaxLen);
            }

            if(!string.IsNullOrEmpty(dto.Description) && dto.Description.Length > Constants.MaxLenOfDecriptionMovie) {
                errors.Add(MovieResource.DescriptionExceedsMaxLen); 
            }

            if(dto.DurationInMinutes < 0 || dto.DurationInMinutes > Constants.MaxAllowDurationInMinutes) {
                errors.Add(MovieResource.IncorrectDuration);
            }

            if(dto.BudgetInDollars < 0 || dto.BudgetInDollars > Constants.MaxAllowBudgetInDollars) {
                errors.Add(MovieResource.IncorrectBudget);
            }

            if(dto.WorldFeesInDollars < 0 || dto.WorldFeesInDollars > Constants.MaxAllowWorldFeesInDollars) {
                errors.Add(MovieResource.IncorrectWorldFees);
            }

            if(dto.PremiereDate < DateTime.UtcNow.AddYears(Constants.CountValidateYear) || dto.PremiereDate > DateTime.UtcNow) {
                errors.Add(MovieResource.IncorrectPremiereDate); 
            }

            return errors; 
        }

        private async Task<ServiceResult> ValidateMovieAndCreatorIdsAsync(Guid movieId, Guid creatorId) {
            if (!await _unitOfWork.GetRepository<Creator>().AnyAsync(x => x.Id == creatorId)) {
                return ServiceResult.Fail(GenericServiceResource.NotFound);
            }

            if (!await _unitOfWork.GetRepository<Movie>().AnyAsync(x => x.Id == movieId)) {
                return ServiceResult.Fail(MovieResource.MovieNotFound);
            }

            return ServiceResult.Ok(); 
        }
    }
}
