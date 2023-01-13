using KinoPoisk.DomainLayer;
using KinoPoisk.DomainLayer.Intarfaces;
using KinoPoisk.DomainLayer.Intarfaces.Services;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using KinoPoisk.DomainLayer.Resources;

namespace KinoPoisk.BusinessLogicLayer.Services.Implementations {
    public abstract class GenericService<TEntity, TEntityDTO, TTypeId> : IService<TTypeId, TEntityDTO>
        where TEntity : class, IEntity<TTypeId>{
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IMapper _mapper;

        public GenericService(IUnitOfWork unitOfWork, IMapper mapper) {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public virtual async Task<Result> CreateAsync(TEntityDTO dto) {
            var errors = Validate(dto);

            if (errors.Count > 0) {
                return Result.Fail(errors);
            }

            var createObj = _mapper.Map<TEntity>(dto);

            _unitOfWork.GetRepository<TEntity>().Create(createObj);
            await _unitOfWork.CommitAsync();

            return Result.Ok(GenericServiceResource.Created);
        }

        public async Task<Result> DeleteAsync(TTypeId id) {
            var obj = _unitOfWork.GetRepository<TEntity>().GetById(id);

            if (obj is null) {
                return Result.Fail(GenericServiceResource.NotFound);
            }

            _unitOfWork.GetRepository<TEntity>().Delete(obj);
            await _unitOfWork.CommitAsync();
            return Result.Ok(GenericServiceResource.Deleted);
        }

        public async Task<Result> GetAllAsync<T>() {
            var objects = _unitOfWork.GetRepository<TEntity>()
                .GetAll()
                .ProjectTo<T>(_mapper.ConfigurationProvider)
                .ToList();

            return Result.Ok(objects);
        }

        public async Task<Result> GetByIdAsync<T>(TTypeId id) {
            var obj = _unitOfWork.GetRepository<TEntity>()
                .GetAll()
                .Where(x => Equals(x.Id,id)) 
                .ProjectTo<T>(_mapper.ConfigurationProvider)
                .FirstOrDefault();

            return obj is null ?
                Result.Fail(GenericServiceResource.NotFound) :
                Result.Ok(_mapper.Map<T>(obj));
        }

        public async Task<Result> UpdateAsync(TEntityDTO dto) {
            var errors = Validate(dto);

            if(errors.Count > 0) {
                return Result.Fail(errors);
            }

            var updateObj = _mapper.Map<TEntity>(dto); 

            if (!_unitOfWork.GetRepository<TEntity>().Contains(updateObj)) {
                return Result.Fail(GenericServiceResource.NotFound);
            }

            _unitOfWork.GetRepository<TEntity>().Update(updateObj);
            await _unitOfWork.CommitAsync();
            return Result.Ok(GenericServiceResource.Updated);
        }

        abstract protected List<string> Validate(TEntityDTO dto);
    }
}
