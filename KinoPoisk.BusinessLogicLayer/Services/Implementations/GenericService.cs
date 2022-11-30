using KinoPoisk.DomainLayer.DTOs.GenreDTO;
using KinoPoisk.DomainLayer.DTOs;
using KinoPoisk.DomainLayer.Entities;
using KinoPoisk.DomainLayer;
using KinoPoisk.DomainLayer.Intarfaces;
using KinoPoisk.DomainLayer.Intarfaces.Services;
using AutoMapper;
using AutoMapper.QueryableExtensions;

namespace KinoPoisk.BusinessLogicLayer.Services.Implementations {
    public class GenericService<TEntity, TTypeId, TCreateDto, TUpdateDto, TGetDto> : IService<TTypeId>
        where TEntity : class
        where TCreateDto : class, ICreateDTO
        where TUpdateDto : class, IUpdateDTO<TTypeId>{
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GenericService(IUnitOfWork unitOfWork, IMapper mapper) {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result> CreateAsync(ICreateDTO createDto) {
            var dto = createDto as TCreateDto;

            if (dto is null) {
                return new ErrorResult(new List<string> { "Argument null" });
            }

            var errors = createDto.ValidateData();

            if (errors.Count() > 0) {
                return new ErrorResult(errors);
            }

            _unitOfWork.GetRepository<TEntity>().Create(_mapper.Map<TEntity>(dto));
            await _unitOfWork.CommitAsync();

            return new SuccessResult<string>("Entity is created");
        }

        public async Task<Result> DeleteAsync(TTypeId id) {
            var obj = _unitOfWork.GetRepository<TEntity>().GetById(id);

            if (obj is null) {
                return new ErrorResult(new List<string> { "Entity not found" });
            }

            _unitOfWork.GetRepository<TEntity>().Delete(obj);
            await _unitOfWork.CommitAsync();
            return new SuccessResult<string>("Entity is deleted");
        }

        public async Task<Result> GetAllAsync() {
            var objects = _unitOfWork.GetRepository<TEntity>()
                .GetAll()
                .ProjectTo<TGetDto>(_mapper.ConfigurationProvider)
                .ToList();

            return new SuccessResult<IEnumerable<TGetDto>>(objects);
        }

        public async Task<Result> GetByIdAsync(TTypeId id) {
            var obj = _unitOfWork.GetRepository<TEntity>().GetById(id);

            return obj is null ?
                new ErrorResult(new List<string>() { "Not found!" }) :
                new SuccessResult<TGetDto>(_mapper.Map<TGetDto>(obj));
        }

        public async Task<Result> UpdateAsync(IUpdateDTO<TTypeId> updateDto) {
            var dto = updateDto as TUpdateDto;

            if (dto is null) {
                new ErrorResult(new List<string> { "Argument null" });
            }

            var errors = dto.ValidateData();

            if (errors.Count() > 0) {
                return new ErrorResult(errors);
            }

            if (_unitOfWork.GetRepository<TEntity>().Contains(dto.Id)) {
                return new ErrorResult(new List<string> { "Not found" });
            }

            var map = _mapper.Map<TEntity>(dto); 
            _unitOfWork.GetRepository<TEntity>().Update(map);
            await _unitOfWork.CommitAsync();
            return new SuccessResult<string>("Entity is updated");
        }
    }

}
