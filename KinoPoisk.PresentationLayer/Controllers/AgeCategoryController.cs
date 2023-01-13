﻿using KinoPoisk.BusinessLogicLayer.Services.Implementations;
using KinoPoisk.DataAccessLayer;
using KinoPoisk.DomainLayer.DTOs.AgeCategoryDTO;
using Microsoft.AspNetCore.Authorization;

namespace KinoPoisk.PresentationLayer.Controllers {
    [Authorize(Roles = Constants.NameRoleAdmin)]
    public class AgeCategoryController : CrudControllerBase<AgeCategoryService, AgeCategoryDTO, GetAgeCategoryDTO, Guid> {
        public AgeCategoryController(AgeCategoryService service) : base(service) {
        }
    }
}
