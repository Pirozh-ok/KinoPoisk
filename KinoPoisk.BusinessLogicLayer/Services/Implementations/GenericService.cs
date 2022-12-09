using KinoPoisk.DomainLayer;
using KinoPoisk.DomainLayer.Intarfaces;
using KinoPoisk.DomainLayer.Intarfaces.Services;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using KinoPoisk.DomainLayer.Resources;

namespace KinoPoisk.BusinessLogicLayer.Services.Implementations {
    public class GenericService<TEntity, TTypeId> : IService<TTypeId>
        where TEntity : class, IEntity<TTypeId>{
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GenericService(IUnitOfWork unitOfWork, IMapper mapper) {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result> CreateAsync<T>(T dto) {
            var createObj = _mapper.Map<TEntity>(dto); 

            _unitOfWork.GetRepository<TEntity>().Create(createObj);
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

        public async Task<Result> GetAllAsync<T>() {
            var objects = _unitOfWork.GetRepository<TEntity>()
                .GetAll()
                .ProjectTo<T>(_mapper.ConfigurationProvider)
                .ToList();

            return new SuccessResult<IEnumerable<T>>(objects);
        }

        public async Task<Result> GetByIdAsync<T>(TTypeId id) {
            var obj = _unitOfWork.GetRepository<TEntity>()
                .GetAll()
                .Where(x => Equals(x.Id,id)) 
                .ProjectTo<T>(_mapper.ConfigurationProvider)
                .FirstOrDefault();

            return obj is null ?
                new ErrorResult(new List<string>() { GenericServiceResource.NotFound }) :
                new SuccessResult<T>(_mapper.Map<T>(obj));
        }

        public async Task<Result> UpdateAsync<T>(T dto) {
            var updateObj = _mapper.Map<TEntity>(dto); 

            if (!_unitOfWork.GetRepository<TEntity>().Contains(updateObj)) {
                return new ErrorResult(new List<string> { GenericServiceResource.NotFound });
            }

            _unitOfWork.GetRepository<TEntity>().Update(updateObj);
            await _unitOfWork.CommitAsync();
            return new SuccessResult<string>(GenericServiceResource.Updated);
        }
    }
}
