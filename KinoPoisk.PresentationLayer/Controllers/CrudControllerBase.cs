using KinoPoisk.BusinessLogicLayer.DTOs;
using KinoPoisk.BusinessLogicLayer.Services.Interfaces;
using KinoPoisk.DataAccessLayerLayer;
using Microsoft.AspNetCore.Mvc;

namespace KinoPoisk.PresentationLayer.Controllers {
    [Route("api/[controller]/")]
    [ApiController]
    public class CrudControllerBase<TService, TCreateOrUpdateDto , TGetDto, TTypeId>: ControllerBase 
        where TService : IService<TTypeId>
        where TGetDto : IGetDto<TTypeId>
        where TCreateOrUpdateDto : IUpdateOrCreateDto{
        protected TService _service;

        public CrudControllerBase(TService service) {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync() {
            return Ok(await _service.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(TTypeId id) {
            return Ok(await _service.GetByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] TCreateOrUpdateDto createDto) {
            await _service.CreateAsync(createDto);
            return StatusCode(201); 
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(TTypeId id) {
            await _service.DeleteAsync(id);
            return StatusCode(204); 
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromQuery] TTypeId id, [FromBody] TCreateOrUpdateDto updateDto) {
            await _service.UpdateAsync(id, updateDto);
            return StatusCode(204); 
        }
    }
}
