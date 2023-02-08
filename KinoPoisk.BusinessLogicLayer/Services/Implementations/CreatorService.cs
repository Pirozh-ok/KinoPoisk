using AutoMapper;
using KinoPoisk.BusinessLogicLayer.Services.Base;
using KinoPoisk.DataAccessLayer;
using KinoPoisk.DomainLayer;
using KinoPoisk.DomainLayer.DTOs.MovieCreatorDTOs;
using KinoPoisk.DomainLayer.DTOs.Pageable;
using KinoPoisk.DomainLayer.Entities;
using KinoPoisk.DomainLayer.Intarfaces.Services;
using KinoPoisk.DomainLayer.Resources;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace KinoPoisk.BusinessLogicLayer.Services.Implementations
{
    public class CreatorService  : SearchableEntityService<CreatorService, Creator, Guid, CreatorDTO, PageableCreatorRequestDto>, ICreatorService{
        public CreatorService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper) {
        }

        protected override ServiceResult Validate(CreatorDTO dto) {
            var errors = new List<string>();

            if (string.IsNullOrEmpty(dto.FirstName) || dto.FirstName.Length < Constants.MinLenOfName) {
                errors.Add(UserResource.FirstNameLessMinLen);
            }

            if (dto.FirstName.Length > Constants.MaxLenOfName) {
                errors.Add(UserResource.FirstNameExceedsMaxLen);
            }

            if (string.IsNullOrEmpty(dto.LastName) || dto.LastName.Length < Constants.MinLenOfName) {
                errors.Add(UserResource.LastNameLessMinLen);
            }

            if (dto.LastName.Length > Constants.MaxLenOfName) {
                errors.Add(UserResource.LastNameExceedsMaxLen);
            }

            if (dto.Patronymic is not null && dto.Patronymic.Length < Constants.MinLenOfName) {
                errors.Add(UserResource.PatronymicLessMinLen);
            }

            if (dto.Patronymic is not null && dto.Patronymic.Length > Constants.MaxLenOfName) {
                errors.Add(UserResource.PatronymicExceedsMaxLen);
            }

            if (dto.DateOfBirth < DateTime.UtcNow.AddYears(-100) || dto.DateOfBirth > DateTime.UtcNow) {
                errors.Add(UserResource.IncorrectDateOfBirth);
            }

            return errors.Count() > 0 ? ServiceResult.Fail(errors) : ServiceResult.Ok();
        }

        protected override List<Expression<Func<Creator, bool>>> GetAdvancedConditions(PageableCreatorRequestDto filters) {
            var conditions = new List<Expression<Func<Creator, bool>>>();

            if (filters.CountMovieFrom is not null) {
                conditions.Add(x => x.CreatorsMovies.GroupBy(x => x.MovieId).Count() > filters.CountMovieFrom);
            }

            if (filters.CountMovieFrom is not null) {
                conditions.Add(x => x.CreatorsMovies.GroupBy(x => x.MovieId).Count() < filters.CountMovieFrom);
            }

            if (filters.AgeFrom is not null) {
                conditions.Add(x => DateTime.UtcNow.Year - x.DateOfBirth.Year > filters.AgeFrom);
            }

            if (filters.AgeTo is not null) {
                conditions.Add(x => DateTime.UtcNow.Year - x.DateOfBirth.Year < filters.AgeTo);
            }

            return conditions;
        }

        protected override IQueryable<Creator> GetEntityByIdIncludes(IQueryable<Creator> query) {
            return query
                .Include(x => x.CreatorsMovies)
                    .ThenInclude(x => x.Roles);                
        }
    }
}
