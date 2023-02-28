using AutoMapper;
using AutoMapper.QueryableExtensions;
using KinoPoisk.BusinessLogicLayer.Services.Base;
using KinoPoisk.DataAccessLayer;
using KinoPoisk.DomainLayer;
using KinoPoisk.DomainLayer.DTOs.MovieCreatorDTOs;
using KinoPoisk.DomainLayer.DTOs.MovieDTOs;
using KinoPoisk.DomainLayer.DTOs.Pageable;
using KinoPoisk.DomainLayer.Entities;
using KinoPoisk.DomainLayer.Intarfaces.Services;
using KinoPoisk.DomainLayer.Resources;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace KinoPoisk.BusinessLogicLayer.Services.Implementations {
    public class MovieService : SearchableEntityService<MovieService, Movie, Guid, MovieDTO, PageableMovieRequestDto>, IMovieService {
        private readonly IAccessService _accessService;
        public MovieService(IUnitOfWork unitOfWork, IMapper mapper, IAccessService accessService) : base(unitOfWork, mapper) {
            _accessService = accessService;
        }

        public async override Task<ServiceResult> CreateAsync(MovieDTO dto) {
            var validationResult = Validate(dto);

            if (validationResult.Failure) {
                return validationResult;
            }

            dto.Id = Guid.Empty;
            var createObj = _mapper.Map<Movie>(dto);

            var countryRepository = _unitOfWork.GetRepository<Country>();
            var genreRepository = _unitOfWork.GetRepository<Genre>();
            var ageCategoryRepository = _unitOfWork.GetRepository<AgeCategory>();

            foreach(var id in dto.CountriesIds) {
                var country = countryRepository.FindById(id);
                
                if(country is not null) {
                    createObj.Countries.Add(country);
                }
            }

            foreach (var id in dto.GenresIds) {
                var genre = genreRepository.FindById(id);

                if (genre is not null) {
                    createObj.Genres.Add(genre);
                }
            }

            foreach (var id in dto.AgeCategoriesIds) {
                var ageCategory = ageCategoryRepository.FindById(id);

                if (ageCategory is not null) {
                    createObj.AgeCategories.Add(ageCategory);
                }
            }

            _unitOfWork.GetRepository<Movie>().Add(createObj);
            await _unitOfWork.CommitAsync();

            return ServiceResult.Ok(GenericServiceResource.Created);
        }

        public async Task<ServiceResult> AddOrUpdateCreatorToMovie(AddCreatorToMovieDTO dto) {

            if(dto is null) {
                return ServiceResult.Fail(MovieResource.NullArgument);
            }

            var validateResult = ValidateMovieAndCreatorIdsAsync(dto.MovieId, dto.CreatorId);

            if (validateResult.Failure) {
                return validateResult;
            }

            var obj = await _unitOfWork.GetRepository<CreatorMovie>()
                .Get(x => x.CreatorId == dto.CreatorId && x.MovieId == dto.MovieId)
                .Include(x => x.Roles)
                .FirstOrDefaultAsync();

            var roles = new List<MovieRole>();

            foreach(var id in dto.Roles) {
                var role = _unitOfWork.GetRepository<MovieRole>().FindById(id);

                if (role is not null){
                    roles.Add(role);
                }
            }

            if (obj is null) {
                _unitOfWork.GetRepository<CreatorMovie>().Add(
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
            var validateResult = ValidateMovieAndCreatorIdsAsync(movieId, creatorId);

            if (validateResult.Failure) {
                return validateResult;
            }

            var obj = _unitOfWork.GetRepository<CreatorMovie>()
                .Get(x => x.CreatorId == creatorId && x.MovieId == movieId, true)
                .FirstOrDefault();

            if(obj is null) {
                return ServiceResult.Fail(GenericServiceResource.NotFound);
            }

            _unitOfWork.GetRepository<CreatorMovie>().Remove(obj);
            await _unitOfWork.CommitAsync();
            return ServiceResult.Ok();
        }

        public async Task<ServiceResult> GetCreaterByMovieAsync(Guid movieId) {
            if(! _unitOfWork.GetRepository<Movie>()
                .Any(x => x.Id == movieId)) {
                return ServiceResult.Fail(MovieResource.MovieNotFound);
            }

            var objs = await _unitOfWork.GetRepository<CreatorMovie>()
                .Get(x => x.MovieId == movieId)
                .ProjectTo<GetCreatorDTO>(_mapper.ConfigurationProvider)
                .ToListAsync();

            return ServiceResult.Ok(objs);
        }

        public async Task<ServiceResult> AddOrUpdateRatingToMovie(RatingDTO dto) {
            var validationResult = ValidateRating(dto);

            if (validationResult.Failure) {
                return validationResult;
            }

            if (!_accessService.IsHasAccess(dto.UserId)) {
                return ServiceResult.Fail(UserResource.AccessDenied);
            }

            var ratingRepository = _unitOfWork.GetRepository<Rating>();
            var rating = ratingRepository
                .FindTracking(x => x.UserId == dto.UserId && x.MovieId == dto.MovieId);

            if (rating is null) {
                var createObj = _mapper.Map<Rating>(dto);
                ratingRepository.Add(createObj);
            }
            else {
                rating.MovieRating = dto.MovieRating;
                rating.Comment = dto.Comment;
                ratingRepository.Update(rating);
            }

            await _unitOfWork.CommitAsync();
            return ServiceResult.Ok();
        }

        public async Task<ServiceResult> RemoveRatingMovie(Guid userId, Guid movieId) {
            var validationResult = ValidateIds(userId, movieId);

            if (validationResult.Failure) {
                return validationResult;
            }

            var obj = _unitOfWork.GetRepository<Rating>()
                .FindTracking(x => x.UserId == userId && x.MovieId == movieId);

            if (obj is null) {
                return ServiceResult.Fail(GenericServiceResource.NotFound);
            }

            _unitOfWork.GetRepository<Rating>().Remove(obj);
            await _unitOfWork.CommitAsync();
            return ServiceResult.Ok(GenericServiceResource.Deleted);
        }

        public ServiceResult GetFullRatingById<TGetDto>(Guid userId, Guid movieId) {
            var validateResult = ValidateIds(userId, movieId);

            if (validateResult.Failure) {
                return validateResult;
            }

            var rating = _unitOfWork.GetRepository<Rating>()
                .Get(x => x.UserId == userId && x.MovieId == movieId)
                .FirstOrDefault();

            return rating is null ? ServiceResult.Fail(GenericServiceResource.NotFound)
                : ServiceResult.Ok(_mapper.Map<TGetDto>(rating));
        }

        public async Task<ServiceResult> GetRatingsByMovieIdAsync<TGetDto>(Guid movieId) {
            if (!MovieExists(movieId)) {
                return ServiceResult.Fail(MovieResource.MovieNotFound);
            }

            var ratings = await _unitOfWork.GetRepository<Rating>()
                .Get(x => x.MovieId == movieId)
                .ProjectTo<TGetDto>(_mapper.ConfigurationProvider)
                .ToListAsync();

            return ServiceResult.Ok(ratings);
        }

        protected override List<Expression<Func<Movie, bool>>> GetAdvancedConditions(PageableMovieRequestDto filters) {
            var conditions = new List<Expression<Func<Movie, bool>>>();

            if (!string.IsNullOrEmpty(filters.SearchText)) {
                conditions.Add(x => x.Title.Contains(filters.SearchText));
            }

            if(filters.RatingFrom is not null) {
                conditions.Add(x => x.Ratings.Sum(x => x.MovieRating) / x.Ratings.Count() > filters.RatingFrom);
            }

            if (filters.RatingTo is not null) {
                conditions.Add(x => x.Ratings.Sum(x => x.MovieRating) / x.Ratings.Count() < filters.RatingTo);
            }

            if(filters.WorldFeesFrom is not null) {
                conditions.Add(x => x.WorldFeesInDollars > filters.WorldFeesFrom);
            }

            if (filters.WorldFeesTo is not null) {
                conditions.Add(x => x.WorldFeesInDollars < filters.WorldFeesTo);
            }

            if(filters.Genre is not null) {
                conditions.Add(x => x.Genres.Any(x => x.Name == filters.Genre));
            }

            if (filters.Country is not null) {
                conditions.Add(x => x.Countries.Any(x => x.Name == filters.Country));
            }

            if(filters.AgeTo is not null) {
                conditions.Add(x => x.AgeCategories.Any(x => x.MinAge <= filters.AgeTo));
            }

            if(filters.DateYearFrom is not null) {
                conditions.Add(x => x.PremiereDate.Year > filters.DateYearFrom.Value);
            }

            if (filters.DateYearTo is not null) {
                conditions.Add(x => x.PremiereDate.Year < filters.DateYearTo.Value);
            }

            if (filters.DurationFrom is not null) {
                conditions.Add(x => x.DurationInMinutes > filters.DurationFrom);
            }

            if (filters.DurationTo is not null) {
                conditions.Add(x => x.DurationInMinutes < filters.DurationTo);
            }

            return conditions;
        }

        protected override IQueryable<Movie> GetEntityByIdIncludes(IQueryable<Movie> query) {
            return query
                .Include(x => x.Genres)
                .Include(x => x.AgeCategories)
                .Include(x => x.Awards)
                .Include(x => x.Contents)
                .Include(x => x.Countries)
                .Include(x => x.CreatorsMovies)
                    .ThenInclude(x => x.Roles)
                .Include(x => x.Ratings); 
        }

        protected override ServiceResult Validate(MovieDTO dto) {
            var errors = new List<string>();

            if(dto is null) {
                errors.Add(MovieResource.NullArgument);
                return ServiceResult.Fail(errors);
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

            return errors.Count() > 0 ? ServiceResult.Fail(errors) : ServiceResult.Ok(); 
        }

        private ServiceResult ValidateMovieAndCreatorIdsAsync(Guid movieId, Guid creatorId) {
            if (!_unitOfWork.GetRepository<Creator>().Any(x => x.Id == creatorId)) {
                return ServiceResult.Fail(GenericServiceResource.NotFound);
            }

            if (!_unitOfWork.GetRepository<Movie>().Any(x => x.Id == movieId)) {
                return ServiceResult.Fail(MovieResource.MovieNotFound);
            }

            return ServiceResult.Ok(); 
        }

        private ServiceResult ValidateRating(RatingDTO dto) {
            var errors = new List<string>();

            if (dto is null) {
                errors.Add(MovieResource.NullArgument);
                return ServiceResult.Fail(errors);
            }

            if (!string.IsNullOrEmpty(dto.Comment) && dto.Comment.Length > Constants.MaxLenOfComment) {
                errors.Add(MovieResource.CommentExceedsMaxLen);
            }

            if (dto.MovieRating < Constants.MinValueRatingMovie || dto.MovieRating > Constants.MaxValueRatingMovie) {
                errors.Add(MovieResource.IncorrectMovieRating);
            }

            if (!MovieExists(dto.MovieId)) {
                errors.Add(MovieResource.MovieNotFound);
            }

            if (!UserExistsAsync(dto.UserId)) {
                errors.Add(MovieResource.UserNotFound);
            }

            return errors.Count > 0 ? ServiceResult.Fail(errors) : ServiceResult.Ok(errors);
        }

        private ServiceResult ValidateIds(Guid userId, Guid movieId) {
            if (!UserExistsAsync(userId)) {
                return ServiceResult.Fail(MovieResource.UserNotFound);
            }

            if (!MovieExists(movieId)) {
                return ServiceResult.Fail(MovieResource.MovieNotFound);
            }

            if (!_accessService.IsHasAccess(userId)) {
                return ServiceResult.Fail(UserResource.AccessDenied);
            }

            return ServiceResult.Ok();
        }

        private bool UserExistsAsync(Guid userId) => _unitOfWork.GetRepository<ApplicationUser>()
            .Any(x => x.Id == userId);

        private bool MovieExists(Guid movieId) => _unitOfWork.GetRepository<Movie>()
            .Any(x => x.Id == movieId);
    }
}
