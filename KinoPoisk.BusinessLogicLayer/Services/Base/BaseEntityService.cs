using AutoMapper;
using AutoMapper.QueryableExtensions;
using KinoPoisk.DomainLayer;
using KinoPoisk.DomainLayer.DTOs;
using KinoPoisk.DomainLayer.Intarfaces;
using KinoPoisk.DomainLayer.Intarfaces.Services;
using KinoPoisk.DomainLayer.Resources;

namespace KinoPoisk.BusinessLogicLayer.Services.Base {
    public abstract class BaseEntityService<TEntity, TKey, TDto> : BaseService, IBaseEntityService<TKey, TDto>
        where TEntity : class, IBaseEntity<TKey>, new()
        where TDto : BaseEntityDto<TKey>
        where TKey : IEquatable<TKey>, new() {

        public BaseEntityService(
            IUnitOfWork unitOfWork,
            IMapper mapper) : base(unitOfWork, mapper) { }

        public virtual async Task<ServiceResult> CreateAsync(TDto dto) {
            var validationResult = Validate(dto);

            if (validationResult.Failure) {
                return ServiceResult.Fail(validationResult.Errors);
            }

            var createObj = BuildEntity(dto);

            _unitOfWork.GetRepository<TEntity>().Add(createObj);
            await _unitOfWork.CommitAsync();

            return ServiceResult.Ok(GenericServiceResource.Created);
        }

        public virtual async Task<ServiceResult> DeleteAsync(TKey id) {
            var obj = _unitOfWork.GetRepository<TEntity>().FindById(id);

            if (obj is null) {
                return ServiceResult.Fail(GenericServiceResource.NotFound);
            }

            _unitOfWork.GetRepository<TEntity>().Remove(obj);
            await _unitOfWork.CommitAsync();

            return ServiceResult.Ok(GenericServiceResource.Deleted);
        }

        public virtual ServiceResult Get<TGetDto>() {
            var objects = _unitOfWork.GetRepository<TEntity>()
                .Get(false)
                .ProjectTo<TGetDto>(_mapper.ConfigurationProvider)
                .ToList();

            return ServiceResult.Ok(objects);
        }

        public ServiceResult GetById<TGetDto>(TKey id) {
            var obj = _unitOfWork.GetRepository<TEntity>()
                .Get(x => x.Id.Equals(id))
                .ProjectTo<TGetDto>(_mapper.ConfigurationProvider)
                .FirstOrDefault();

            return obj is not null ?
                ServiceResult.Ok(_mapper.Map<TGetDto>(obj)) :
                ServiceResult.Fail(GenericServiceResource.NotFound);
        }

        public virtual async Task<ServiceResult> UpdateAsync(TDto dto) {
            var validationResult = Validate(dto);

            if (validationResult.Failure) {
                return ServiceResult.Fail(validationResult.Errors);
            }

            var updateObj = _mapper.Map<TEntity>(dto);

            if (!_unitOfWork.GetRepository<TEntity>().Any(x => x.Id.Equals(dto.Id))) {
                return ServiceResult.Fail(GenericServiceResource.NotFound);
            }

            _unitOfWork.GetRepository<TEntity>().Update(updateObj);
            await _unitOfWork.CommitAsync();
            return ServiceResult.Ok(GenericServiceResource.Updated);
        }

        protected virtual TEntity BuildEntity(TDto dto) {
            var entity = new TEntity();
            _mapper.Map(dto, entity);
            entity.Id = GetNewKey(); 

            return entity;
        }

        abstract protected ServiceResult Validate(TDto dto);

        protected virtual IQueryable<TEntity> GetEntityByIdIncludes(IQueryable<TEntity> query) {
            return query;
        }

        protected virtual TKey GetNewKey() {
            return new TKey();
        }
    }
}
