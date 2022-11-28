using KinoPoisk.DomainLayer.DTOs.GenreDTOs;
using KinoPoisk.DomainLayer.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace KinoPoisk.PresentationLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class GenreController : CrudControllerBase<IGenreService, CreateGenreDto, UpdateGenreDTO<Guid>, GetGenreDTO, Guid> {
        public GenreController(IGenreService service) : base(service) {
        }
    }
}
