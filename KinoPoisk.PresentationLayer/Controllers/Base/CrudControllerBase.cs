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
            var result = await _service.GetAsync<TGetDto>(); 
            return GetResult(result, (int)HttpStatusCode.OK);
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public virtual async Task<IActionResult> GetByIdAsync(TKey id)
        {
            var result = await _service.GetByIdAsync<TGetDto>(id);
            return GetResult(result, (int)HttpStatusCode.OK);
        }

        [HttpPost]
        public virtual async Task<IActionResult> CreateAsync([FromBody] TEntityDTO createDto)
        {
            var result = await _service.CreateAsync(createDto);
            return GetResult(result, (int)HttpStatusCode.Created);
        }

        [HttpDelete("{id}")]
        public virtual async Task<IActionResult> DeleteAsync(TKey id)
        {
            var result = await _service.DeleteAsync(id);
            return GetResult(result, (int)HttpStatusCode.NoContent);
        }

        [HttpPut]
        public virtual async Task<IActionResult> UpdateAsync([FromBody] TEntityDTO updateDto)
        {
            var result = await _service.UpdateAsync(updateDto);
            return GetResult(result, (int)HttpStatusCode.NoContent);
        }
    }
}
