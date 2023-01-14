using AutoMapper;
using KinoPoisk.DataAccessLayer;
using KinoPoisk.DomainLayer;
using KinoPoisk.DomainLayer.DTOs.MovieDTOs;
using KinoPoisk.DomainLayer.Entities;
using KinoPoisk.DomainLayer.Intarfaces.Services;
using KinoPoisk.DomainLayer.Resources;
using Microsoft.AspNetCore.Http;
using System.IdentityModel.Tokens.Jwt;

namespace KinoPoisk.BusinessLogicLayer.Services.Implementations {
    public class MovieService : GenericService<Movie, MovieDTO, Guid> {
        private readonly IHttpContextAccessor _accessor;
        public MovieService(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor accessor) : base(unitOfWork, mapper) {
            _accessor = accessor;
        }

        public async override Task<Result> CreateAsync(MovieDTO dto) {
            var errors = Validate(dto);

            if (errors.Count > 0) {
                return Result.Fail(errors);
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

            _unitOfWork.GetRepository<Movie>().Create(createObj);
            await _unitOfWork.CommitAsync();

            return Result.Ok(GenericServiceResource.Created);
        }

        public async Task<Result> CreateOrUpdateRating(RatingDTO rating) {
            var errors = ValidateRating(rating);

            if(errors.Count > 0) {
                return Result.Fail(errors); 
            }

            var ratingRepository = _unitOfWork.GetRepository<Rating>();
            var createObj = _mapper.Map<Rating>(rating);
            createObj.UserId = Guid.Parse(GetAuthUserId());

            ratingRepository.Create(createObj);
            await _unitOfWork.CommitAsync();

            return Result.Ok();
        }

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

        private List<string> ValidateRating(RatingDTO dto) {
            var errors = new List<string>();

            if(dto is null) {
                errors.Add(MovieResource.NullArgument);
                return errors;
            }

            if(!string.IsNullOrEmpty(dto.Comment) && dto.Comment.Length > Constants.MaxLenOfComment) {
                errors.Add(MovieResource.CommentExceedsMaxLen);
            }

            if(dto.MovieRating < Constants.MinValueRatingMovie || dto.MovieRating > Constants.MaxValueRatingMovie) {
                errors.Add(MovieResource.IncorrectMovieRating);
            }

            if(_unitOfWork.GetRepository<Movie>().GetById(dto.MovieId) is null) {
                errors.Add(MovieResource.MovieNotFound);
            }

            return errors; 
        }

        private string? GetAuthUserId() => _accessor.HttpContext.User.Claims
            .FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Jti)?.Value;
    }
}
