using KinoPoisk.BusinessLogicLayer.DTOs;
using KinoPoisk.BusinessLogicLayer.Services.Interfaces;
using KinoPoisk.DataAccessLayer;
using Microsoft.AspNetCore.Mvc;

namespace KinoPoisk.PresentationLayer.Controllers {
    [Route("api/[controller]/")]
    [ApiController]
    public class CrudControllerBase<TService, TEntity, TCreateOrUpdateDto , TGetDto, TTypeId>: ControllerBase 
        where TService : IService<TTypeId>
        where TEntity : IEntity
        where TGetDto : IGetDto<TTypeId>
        where TCreateOrUpdateDto : IUpdateOrCreateDto{
        private TService _service;

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
        public async Task<IActionResult> UpdateAsync([FromBody] TCreateOrUpdateDto updateDto) {
            await _service.UpdateAsync(updateDto);
            return StatusCode(204); 
        }
    }
}
