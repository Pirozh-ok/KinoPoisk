using KinoPoisk.DomainLayer.DTOs;
using KinoPoisk.DomainLayer;
using KinoPoisk.DomainLayer.Intarfaces;
using KinoPoisk.DomainLayer.Intarfaces.Services;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using KinoPoisk.DomainLayer.Resources;

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
                return new ErrorResult(new List<string> { GenericServiceResource.NullArgument });
            }

            var errors = createDto.ValidateData();

            if (errors.Count() > 0) {
                return new ErrorResult(errors);
            }

            _unitOfWork.GetRepository<TEntity>().Create(_mapper.Map<TEntity>(dto));
            await _unitOfWork.CommitAsync();

            return new SuccessResult<string>(GenericServiceResource.Created);
        }

        public async Task<Result> DeleteAsync(TTypeId id) {
            var obj = _unitOfWork.GetRepository<TEntity>().GetById(id);

            if (obj is null) {
                return new ErrorResult(new List<string> { GenericServiceResource.NotFound });
            }

            _unitOfWork.GetRepository<TEntity>().Delete(obj);
            await _unitOfWork.CommitAsync();
            return new SuccessResult<string>(GenericServiceResource.Deleted);
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
                new ErrorResult(new List<string>() { GenericServiceResource.NotFound }) :
                new SuccessResult<TGetDto>(_mapper.Map<TGetDto>(obj));
        }

        public async Task<Result> UpdateAsync(IUpdateDTO<TTypeId> updateDto) {
            var dto = updateDto as TUpdateDto;

            if (dto is null) {
                new ErrorResult(new List<string> { GenericServiceResource.NullArgument });
            }

            var errors = dto.ValidateData();

            if (errors.Count() > 0) {
                return new ErrorResult(errors);
            }

            var mapObj = _mapper.Map<TEntity>(dto);

            if (!_unitOfWork.GetRepository<TEntity>().Contains(mapObj)) {
                return new ErrorResult(new List<string> { GenericServiceResource.NotFound });
            }

            _unitOfWork.GetRepository<TEntity>().Update(mapObj);
            await _unitOfWork.CommitAsync();
            return new SuccessResult<string>(GenericServiceResource.Updated);
        }
    }
}
