using AutoMapper;
using KinoPoisk.DataAccessLayer;
using KinoPoisk.DomainLayer;
using KinoPoisk.DomainLayer.DTOs.AwardDTOs;
using KinoPoisk.DomainLayer.Entities;
using KinoPoisk.DomainLayer.Intarfaces.Services;
using KinoPoisk.DomainLayer.Resources;

namespace KinoPoisk.BusinessLogicLayer.Services.Implementations {
    public class AwardService : GenericService<Award, AwardDTO, Guid> {
        public AwardService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper) {
        }

        public override async Task<Result> CreateAsync(AwardDTO dto) {
            var errors = Validate(dto);

            if (errors.Count > 0) {
                return Result.Fail(errors);
            }

            dto.Id = Guid.Empty; 
            var createObj = _mapper.Map<Award>(dto);

            await _unitOfWork.GetRepository<Award>().Create(createObj);
            await _unitOfWork.CommitAsync();

            return Result.Ok(GenericServiceResource.Created);
        }

        protected override List<string> Validate(AwardDTO dto) {
            var errors = new List<string>();

            if(dto is null) {
                errors.Add(AwardResource.NullArgument);
                return errors; 
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

            if (_unitOfWork.GetRepository<Movie>().GetById(dto.MovieId) is null) {
                errors.Add(AwardResource.MovieNotFound); 
            }

            return errors; 
        }
    }
}
