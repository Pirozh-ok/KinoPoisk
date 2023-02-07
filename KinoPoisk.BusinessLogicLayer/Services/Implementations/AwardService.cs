using AutoMapper;
using KinoPoisk.BusinessLogicLayer.Services.Base;
using KinoPoisk.DataAccessLayer;
using KinoPoisk.DomainLayer;
using KinoPoisk.DomainLayer.DTOs.AwardDTOs;
using KinoPoisk.DomainLayer.Entities;
using KinoPoisk.DomainLayer.Intarfaces.Services;
using KinoPoisk.DomainLayer.Resources;

namespace KinoPoisk.BusinessLogicLayer.Services.Implementations
{
    public class AwardService : BaseEntityService<Award, Guid, AwardDTO>, IAwardService {
        public AwardService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper) {
        }

        public override async Task<ServiceResult> CreateAsync(AwardDTO dto) {
            var validationResult = Validate(dto);

            if (validationResult.Failure) {
                return validationResult;
            }

            dto.Id = Guid.Empty; 
            var createObj = _mapper.Map<Award>(dto);

            _unitOfWork.GetRepository<Award>().Add(createObj);
            await _unitOfWork.CommitAsync();

            return ServiceResult.Ok(GenericServiceResource.Created);
        }

        protected override ServiceResult Validate(AwardDTO dto) {
            var errors = new List<string>();

            if(dto is null) {
                errors.Add(AwardResource.NullArgument);
                return ServiceResult.Fail(errors); 
            }

            if(string.IsNullOrEmpty(dto.Name) || dto.Name.Length < Constants.MinLenOfName) {
                errors.Add(AwardResource.NameLessMinLen);
            }

            if(dto.Name.Length > Constants.MaxLenOfNameAward) {
                errors.Add(AwardResource.NameExceedsMaxLen); 
            }

            if(dto.DateOfAward < DateTime.UtcNow.AddYears(Constants.CountValidateYear) || dto.DateOfAward > DateTime.UtcNow) {
                errors.Add(AwardResource.IncorrectData); 
            }

            if (!_unitOfWork.GetRepository<Movie>().Any(x => x.Id == dto.MovieId)) {
                errors.Add(AwardResource.MovieNotFound); 
            }

            return errors.Count() > 0 ? ServiceResult.Fail(errors) : ServiceResult.Ok();
        }
    }
}
