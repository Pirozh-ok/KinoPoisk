using KinoPoisk.DomainLayer;
using KinoPoisk.DomainLayer.Intarfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace KinoPoisk.PresentationLayer.Controllers {
    [Route("api/[controller]/")]
    [ApiController]
    public class CrudControllerBase<TService, TEntityDTO , TGetDto, TTypeId>: ControllerBase 
        where TService : IService<TTypeId,TEntityDTO > {
        protected TService _service;

        public CrudControllerBase(TService service) {
            _service = service;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetAllAsync() {
            return Ok(await _service.GetAllAsync<TGetDto>());
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetByIdAsync(TTypeId id) {
            var result = await _service.GetByIdAsync<TGetDto>(id);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] TEntityDTO createDto) {
            var result = await _service.CreateAsync(createDto);
            return result.Success ? StatusCode((int)HttpStatusCode.Created) : BadRequest(result); 
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(TTypeId id) {
            var result = await _service.DeleteAsync(id);
            return result.Success ? StatusCode((int)HttpStatusCode.NoContent) : BadRequest(result); 
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody] TEntityDTO updateDto) {
            var result = await _service.UpdateAsync(updateDto);
            return result.Success ? StatusCode((int)HttpStatusCode.NoContent) : BadRequest(result); 
        }
    }
}
