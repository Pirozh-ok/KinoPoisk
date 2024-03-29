﻿using AutoMapper;
using KinoPoisk.BusinessLogicLayer.Services.Base;
using KinoPoisk.DataAccessLayer;
using KinoPoisk.DomainLayer;
using KinoPoisk.DomainLayer.DTOs.AgeCategoryDTO;
using KinoPoisk.DomainLayer.Entities;
using KinoPoisk.DomainLayer.Intarfaces.Services;
using KinoPoisk.DomainLayer.Resources;

namespace KinoPoisk.BusinessLogicLayer.Services.Implementations
{
    public class AgeCategoryService : BaseEntityService<AgeCategory, Guid, AgeCategoryDTO>, IAgeCategoryService {
        public AgeCategoryService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper) {
        }

        protected override ServiceResult Validate(AgeCategoryDTO dto) {
            var errors = new List<string>();

            if(dto is null) {
                errors.Add(AgeCategoryResource.NullArgument); 
            }

            if(dto?.MinAge < Constants.MinMinAge) {
                errors.Add(AgeCategoryResource.MinAgeLessMinValue); 
            }

            if (dto?.MinAge > Constants.MaxMinAge) {
                errors.Add(AgeCategoryResource.MinAgeExceedsMaxValue);
            }

            if (string.IsNullOrEmpty(dto?.Value)) {
                errors.Add(AgeCategoryResource.EmptyOrNullValue); 
            }

            if(dto?.Value.Length > Constants.MaxLenOfValueAgeCategory) {
                errors.Add(AgeCategoryResource.ValueExceedsMaxLen); 
            }

            return errors.Count() > 0 ? ServiceResult.Fail(errors) : ServiceResult.Ok();
        }
    }
}
