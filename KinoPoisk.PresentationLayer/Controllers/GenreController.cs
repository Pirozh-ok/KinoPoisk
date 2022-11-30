using KinoPoisk.DomainLayer.DTOs.GenreDTO;
using KinoPoisk.DomainLayer.Intarfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace KinoPoisk.PresentationLayer.Controllers {
    public class GenreController : CrudControllerBase<IGenreService, CreateGenreDto, UpdateGenreDTO<Guid>, GetGenreDTO, Guid> {
        public GenreController(IGenreService service) : base(service) {
        }
    }
}
