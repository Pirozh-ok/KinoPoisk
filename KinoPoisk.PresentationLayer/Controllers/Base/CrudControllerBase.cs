using KinoPoisk.DomainLayer.Intarfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace KinoPoisk.PresentationLayer.Controllers.Base
{
    [Authorize]
    public class CrudControllerBase<TService, TEntityDTO, TGetDto, TKey> : BaseController
        where TService : IBaseEntityService<TKey, TEntityDTO>
        where TKey : IEquatable<TKey>
    {
        protected TService _service;

        public CrudControllerBase(TService service)
        {
            _service = service;
        }

        [HttpGet]
        [AllowAnonymous]
        public virtual async Task<IActionResult> GetAllAsync()
        {
            return Ok(await _service.GetAsync<TGetDto>());
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public virtual async Task<IActionResult> GetByIdAsync(TKey id)
        {
            var result = await _service.GetByIdAsync<TGetDto>(id);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost]
        public virtual async Task<IActionResult> CreateAsync([FromBody] TEntityDTO createDto)
        {
            var result = await _service.CreateAsync(createDto);
            return result.Success ? StatusCode((int)HttpStatusCode.Created) : BadRequest(result);
        }

        [HttpDelete("{id}")]
        public virtual async Task<IActionResult> DeleteAsync(TKey id)
        {
            var result = await _service.DeleteAsync(id);
            return result.Success ? StatusCode((int)HttpStatusCode.NoContent) : BadRequest(result);
        }

        [HttpPut]
        public virtual async Task<IActionResult> UpdateAsync([FromBody] TEntityDTO updateDto)
        {
            var result = await _service.UpdateAsync(updateDto);
            return result.Success ? StatusCode((int)HttpStatusCode.NoContent) : BadRequest(result);
        }
    }
}
