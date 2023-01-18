﻿using KinoPoisk.BusinessLogicLayer.Services.Implementations;
using KinoPoisk.DataAccessLayer;
using KinoPoisk.DomainLayer.DTOs.ContentDTOs;
using Microsoft.AspNetCore.Authorization;

namespace KinoPoisk.PresentationLayer.Controllers {
    [Authorize(Roles = Constants.NameRoleAdmin)]
    public class ContentController : CrudControllerBase<ContentService, ContentDTO, GetContentDTO, Guid> {
        public ContentController(ContentService service) : base(service) {
        }
    }
}