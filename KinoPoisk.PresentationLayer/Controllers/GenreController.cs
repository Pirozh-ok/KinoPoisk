using KinoPoisk.BusinessLogicLayer.DTOs.GenreDTOs;
using KinoPoisk.BusinessLogicLayer.Services.Interfaces;
using KinoPoisk.DomainLayer.Entities;
using Microsoft.AspNetCore.Mvc;

namespace KinoPoisk.PresentationLayer.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class GenreController : CrudControllerBase<IGenreService, CreateUpdateGenreDTO, GetGenreDTO, Guid> {
        public GenreController(IGenreService service) : base(service) {
        }
    }
}
