using AutoMapper;
using AutoMapper.QueryableExtensions;
using KinoPoisk.DomainLayer;
using KinoPoisk.DomainLayer.Intarfaces;
using KinoPoisk.DomainLayer.Intarfaces.Services;
using KinoPoisk.DomainLayer.Resources;

namespace KinoPoisk.BusinessLogicLayer.Services.Base {
    public abstract class BaseEntityService<TEntity, TKey, TDto> : BaseService, IBaseEntityService<TKey, TDto>
        where TEntity : class, IBaseEntity<TKey>, new()
        where TDto : class
        where TKey : IEquatable<TKey> {

        public BaseEntityService(
            IUnitOfWork unitOfWork,
            IMapper mapper) : base(unitOfWork, mapper) { }

        public virtual async Task<ServiceResult> CreateAsync(TDto dto) {
            var errors = Validate(dto);

            if (errors.Count > 0) {
                return ServiceResult.Fail(errors);
            }

            var createObj = _mapper.Map<TEntity>(dto);

            await _unitOfWork.GetRepository<TEntity>().CreateAsync(createObj);
            await _unitOfWork.CommitAsync();

            return ServiceResult.Ok(GenericServiceResource.Created);
        }

        public virtual async Task<ServiceResult> DeleteAsync(TKey id) {
            var obj = _unitOfWork.GetRepository<TEntity>().GetById(id);

            if (obj is null) {
                return ServiceResult.Fail(GenericServiceResource.NotFound);
            }

            _unitOfWork.GetRepository<TEntity>().Delete(obj);
            await _unitOfWork.CommitAsync();
            return ServiceResult.Ok(GenericServiceResource.Deleted);
        }

        public async Task<ServiceResult> GetAllAsync<TGetDto>() {
            var objects = _unitOfWork.GetRepository<TEntity>()
                .GetAll()
                .ProjectTo<TGetDto>(_mapper.ConfigurationProvider)
                .ToList();

            return ServiceResult.Ok(objects);
        }

        public async Task<ServiceResult> GetByIdAsync<TGetDto>(TKey id) {
            var obj = _unitOfWork.GetRepository<TEntity>()
                .GetAll()
                .Where(x => Equals(x.Id, id))
                .FirstOrDefault();

            return obj is not null ?
                ServiceResult.Ok(_mapper.Map<TGetDto>(obj)) :
                ServiceResult.Fail(GenericServiceResource.NotFound);
        }

        public virtual async Task<ServiceResult> UpdateAsync(TDto dto) {
            var errors = Validate(dto);

            if (errors.Count > 0) {
                return ServiceResult.Fail(errors);
            }

            var updateObj = _mapper.Map<TEntity>(dto);

            if (!await _unitOfWork.GetRepository<TEntity>().Contains(updateObj)) {
                return ServiceResult.Fail(GenericServiceResource.NotFound);
            }

            _unitOfWork.GetRepository<TEntity>().Update(updateObj);
            await _unitOfWork.CommitAsync();
            return ServiceResult.Ok(GenericServiceResource.Updated);
        }

        abstract protected List<string> Validate(TDto dto);

        protected virtual IQueryable<TEntity> GetEntityByIdIncludes(IQueryable<TEntity> query) {
            return query;
        }
    }
}
