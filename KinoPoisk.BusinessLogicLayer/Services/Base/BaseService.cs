using KinoPoisk.DomainLayer;
using KinoPoisk.DomainLayer.Intarfaces;
using KinoPoisk.DomainLayer.Intarfaces.Services;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using KinoPoisk.DomainLayer.Resources;

namespace KinoPoisk.BusinessLogicLayer.Services.Base
{
    public abstract class BaseService {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IMapper _mapper;

        public BaseService(IUnitOfWork unitOfWork, IMapper mapper) {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
    }
}
