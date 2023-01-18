﻿using KinoPoisk.BusinessLogicLayer.Services.Implementations;
using KinoPoisk.DataAccessLayer;
using KinoPoisk.DomainLayer.DTOs.MovieCreatorDTOs;
using Microsoft.AspNetCore.Authorization;

namespace KinoPoisk.PresentationLayer.Controllers {
    [Authorize(Roles = Constants.NameRoleAdmin)]
    public class CreatorController : CrudControllerBase<CreatorService, CreatorDTO, GetCreatorDTO, Guid> {
        public CreatorController(CreatorService service) : base(service) {
        }
    }
}