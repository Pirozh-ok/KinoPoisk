using KinoPoisk.BusinessLogicLayer.Services.Implementations;
using KinoPoisk.DomainLayer.DTOs.GenreDTO;

namespace KinoPoisk.PresentationLayer.Controllers {
    public class GenreController : CrudControllerBase<GenreService,GenreDTO, GetGenreDTO, Guid> {
        public GenreController(GenreService service) : base(service) {
        }
    }
}
