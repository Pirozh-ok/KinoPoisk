﻿//using AutoMapper;
//using KinoPoisk.DomainLayer.DTOs.MovieDTOs;
//using KinoPoisk.DomainLayer.Entities;
//using KinoPoisk.DomainLayer;
//using KinoPoisk.DomainLayer.Intarfaces.Services;
//using KinoPoisk.DomainLayer.Resources;
//using KinoPoisk.DataAccessLayer;
//using AutoMapper.QueryableExtensions;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.AspNetCore.Identity;

//namespace KinoPoisk.BusinessLogicLayer.Services.Implementations {
//    public class RatingService {
//        protected readonly IUnitOfWork _unitOfWork;
//        protected readonly IMapper _mapper;
//        private readonly UserManager<ApplicationUser> _userManager;
//        private readonly IAccessService _accessService;

//        public RatingService(
//            IUnitOfWork unitOfWork,
//            IMapper mapper,
//            IAccessService accessService,
//            UserManager<ApplicationUser> userManager) {
//            _unitOfWork = unitOfWork;
//            _mapper = mapper;
//            _accessService = accessService;
//            _userManager = userManager;
//        }

//        public async Task<ServiceResult> CreateOrUpdateRatingAsync(RatingDTO dto) {
//            var validationResult = ValidateRating(dto);

//            if (errors.Count() > 0) {
//                return ServiceResult.Fail(errors);
//            }

//            if (!_accessService.IsHasAccess(dto.UserId)) {
//                return ServiceResult.Fail(UserResource.AccessDenied);
//            }

//            var ratingRepository = _unitOfWork.GetRepository<Rating>();
//            var rating = ratingRepository
//                .FindTracking(x => x.UserId == dto.UserId && x.MovieId == dto.MovieId);

//            if (rating is null) {
//                var createObj = _mapper.Map<Rating>(dto);
//                ratingRepository.Add(createObj);
//            }
//            else {
//                rating.MovieRating = dto.MovieRating;
//                rating.Comment = dto.Comment; 
//                ratingRepository.Update(rating);
//            }

//            await _unitOfWork.CommitAsync();
//            return ServiceResult.Ok();
//        }

//        public async Task<ServiceResult> DeleteAsync(Guid userId, Guid movieId) {
//            var validate = ValidateIds(userId, movieId);
            
//            if (validate.Failure) {
//                return validate; 
//            }

//            var obj = _unitOfWork.GetRepository<Rating>()
//                .FindTracking(x => x.UserId == userId && x.MovieId == movieId);

//            if (obj is null) {
//                return ServiceResult.Fail(GenericServiceResource.NotFound);
//            }

//            _unitOfWork.GetRepository<Rating>().Remove(obj);
//            await _unitOfWork.CommitAsync();
//            return ServiceResult.Ok(GenericServiceResource.Deleted);
//        }

//        public async Task<ServiceResult> GetAllAsync<T>() {
//            var ratings = await _unitOfWork.GetRepository<Rating>()
//                .Get()
//                .ProjectTo<T>(_mapper.ConfigurationProvider)
//                .ToListAsync();

//            return ServiceResult.Ok(ratings);
//        }

//        public async Task<ServiceResult> GetByIdAsync<T>(Guid userId, Guid movieId) {
//            var validate = await ValidateIds(userId, movieId);

//            if (validate.Failure) {
//                return validate; 
//            }

//            var rating = _unitOfWork.GetRepository<Rating>()
//                .Get(x => x.UserId == userId && x.MovieId == movieId)
//                .FirstOrDefault();

//            return rating is null ? ServiceResult.Fail(GenericServiceResource.NotFound) 
//                : ServiceResult.Ok(_mapper.Map<GetRatingDTO>(rating));
//        }

//        public async Task<ServiceResult> GetAllByMovieIdAsync<T>(Guid movieId) {
//            if (!MovieExists(movieId)) {
//                return ServiceResult.Fail(MovieResource.MovieNotFound);
//            }

//            var ratings = await _unitOfWork.GetRepository<Rating>()
//                .Get(x => x.MovieId == movieId)
//                .ProjectTo<T>(_mapper.ConfigurationProvider)
//                .ToListAsync();

//            return ServiceResult.Ok(ratings);
//        }
//    }
//}