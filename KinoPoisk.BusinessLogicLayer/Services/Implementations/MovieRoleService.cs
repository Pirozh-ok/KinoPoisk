using AutoMapper;
using KinoPoisk.DataAccessLayer;
using KinoPoisk.DomainLayer.DTOs.MovieRoleDTOs;
using KinoPoisk.DomainLayer.Entities;
using KinoPoisk.DomainLayer.Intarfaces.Services;
using KinoPoisk.DomainLayer.Resources;

namespace KinoPoisk.BusinessLogicLayer.Services.Implementations {
    public class MovieRoleService : GenericService<MovieRole, MovieRoleDTO, Guid> {
        public MovieRoleService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper) {
        }
        protected override List<string> Validate(MovieRoleDTO dto) {
            var errors = new List<string>();

            if(dto is null) {
                errors.Add(MovieRoleResource.NullArgument); 
            }

            if (string.IsNullOrEmpty(dto.Name) || dto.Name.Length < Constants.MinLenOfName) {
                errors.Add(MovieRoleResource.NameLessMinLen);
            }

            if (dto.Name.Length > Constants.MaxLenOfName) {
                errors.Add(MovieRoleResource.NameExceedsMaxLen);
            }

            return errors;
        }
    }
}
