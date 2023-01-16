using AutoMapper;
using KinoPoisk.DomainLayer.DTOs.MovieDTOs;
using KinoPoisk.DomainLayer.Entities;
using KinoPoisk.DomainLayer;
using KinoPoisk.DomainLayer.Intarfaces.Services;
using KinoPoisk.DomainLayer.Resources;
using KinoPoisk.DataAccessLayer;
using Microsoft.AspNetCore.Http;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace KinoPoisk.BusinessLogicLayer.Services.Implementations {
    public class RatingService {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IMapper _mapper;
        private readonly IHttpContextAccessor _accessor;
        private readonly UserManager<ApplicationUser> _userManager;

        public RatingService(IUnitOfWork unitOfWork,
            IMapper mapper,
            IHttpContextAccessor accessor,
            UserManager<ApplicationUser> userManager) {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _accessor = accessor;
            _userManager = userManager;
        }

        public async Task<Result> CreateOrUpdateRatingAsync(RatingDTO dto) {
            var errors = await ValidateRating(dto);

            if (errors.Count > 0) {
                return Result.Fail(errors);
            }

            if (!AuthUserInfo.IsHasAccess(dto.UserId.ToString(), _accessor)) {
                return Result.Fail(UserResource.AccessDenied);
            }

            var ratingRepository = _unitOfWork.GetRepository<Rating>();
            var rating = await ratingRepository
                .GetByFilter(x => x.UserId == dto.UserId && x.MovieId == dto.MovieId);

            if (rating is null) {
                var createObj = _mapper.Map<Rating>(dto);
                await ratingRepository.Create(createObj);
            }
            else {
                rating.MovieRating = dto.MovieRating;
                rating.Comment = dto.Comment; 
                ratingRepository.Update(rating);
            }

            await _unitOfWork.CommitAsync();
            return Result.Ok();
        }

        public virtual async Task<Result> DeleteAsync(Guid userId, Guid movieId) {
            var validate = await ValidateIds(userId, movieId);
            
            if (validate.Failure) {
                return validate; 
            }

            var obj = await _unitOfWork.GetRepository<Rating>()
                .GetByFilter(x => x.UserId == userId && x.MovieId == movieId);

            if (obj is null) {
                return Result.Fail(GenericServiceResource.NotFound);
            }

            _unitOfWork.GetRepository<Rating>().Delete(obj);
            await _unitOfWork.CommitAsync();
            return Result.Ok(GenericServiceResource.Deleted);
        }

        public async Task<Result> GetAllAsync<T>() {
            var ratings = await _unitOfWork.GetRepository<Rating>()
                .GetAll()
                .ProjectTo<T>(_mapper.ConfigurationProvider)
                .ToListAsync();

            return Result.Ok(ratings);
        }

        public async Task<Result> GetByIdAsync<T>(Guid userId, Guid movieId) {
            var rating = await _unitOfWork.GetRepository<Rating>()
                .GetByFilter(x => x.UserId == userId && x.MovieId == movieId);

            return rating is null ? Result.Fail(GenericServiceResource.NotFound) 
                : Result.Ok(_mapper.Map<GetRatingDTO>(rating));
        }

        public async Task<Result> GetAllByUserIdAsync<T>(Guid userId) {
            var ratings = await _unitOfWork.GetRepository<Rating>()
                .GetAllByFilter(x => x.UserId == userId)
                .ProjectTo<T>(_mapper.ConfigurationProvider)
                .ToListAsync();

            return Result.Ok(ratings);
        }

        public async Task<Result> GetAllByMovieIdAsync<T>(Guid movieId) {
            var ratings = await _unitOfWork.GetRepository<Rating>()
                .GetAllByFilter(x => x.MovieId == movieId)
                .ProjectTo<T>(_mapper.ConfigurationProvider)
                .ToListAsync();

            return Result.Ok(ratings);
        }

        private async Task<List<string>> ValidateRating(RatingDTO dto) {
            var errors = new List<string>();

            if (dto is null) {
                errors.Add(MovieResource.NullArgument);
                return errors;
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

            if (!await UserExistsAsync(dto.UserId)) {
                errors.Add(MovieResource.UserNotFound);
            }

            return errors;
        }

        private async Task<Result> ValidateIds(Guid userId, Guid movieId) {
            if (!await UserExistsAsync(userId)) {
                return Result.Fail(MovieResource.UserNotFound);
            }

            if (!MovieExists(movieId)) {
                return Result.Fail(MovieResource.MovieNotFound);
            }

            if (!AuthUserInfo.IsHasAccess(userId.ToString(), _accessor)) {
                return Result.Fail(UserResource.AccessDenied);
            }

            return Result.Ok();
        }

        private async Task<bool> UserExistsAsync(Guid userId) => await _userManager.FindByIdAsync(userId.ToString()) is not null;

        private bool MovieExists(Guid movieId) => _unitOfWork.GetRepository<Movie>().GetById(movieId) is not null;
    }
}
