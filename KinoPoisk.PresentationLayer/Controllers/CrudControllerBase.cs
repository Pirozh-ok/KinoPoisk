using KinoPoisk.DomainLayer;
using KinoPoisk.DomainLayer.DTOs;
using KinoPoisk.DomainLayer.Intarfaces;
using KinoPoisk.DomainLayer.Resources;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace KinoPoisk.PresentationLayer.Controllers {
    [Route("api/[controller]/")]
    [ApiController]
    public class CrudControllerBase<TService, TCreateDto, TUpdateDto , TGetDto, TTypeId>: ControllerBase 
        where TService : IService<TTypeId>
        where TCreateDto : IValidate
        where TUpdateDto : IUpdateDTO<TTypeId> {
        protected TService _service;

        public CrudControllerBase(TService service) {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync() {
            return Ok(await _service.GetAllAsync<TGetDto>());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(TTypeId id) {
            var result = await _service.GetByIdAsync<TGetDto>(id);
            return result is ErrorResult ? BadRequest(result) : Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] TCreateDto createDto) {
            var errors = ValidateDto(createDto);

            if (errors.Count() > 0) {
                return BadRequest(new ErrorResult(errors));
            }

            var result = await _service.CreateAsync(createDto);
            return StatusCode((int)HttpStatusCode.Created); 
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(TTypeId id) {
            var result = await _service.DeleteAsync(id);
            return result is ErrorResult ? BadRequest(result) : StatusCode((int)HttpStatusCode.NoContent); 
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody] TUpdateDto updateDto) {
            var errors = ValidateDto(updateDto); 

            if(errors.Count() > 0) {
                return BadRequest(new ErrorResult(errors));
            }

            var result = await _service.UpdateAsync(updateDto);
            return StatusCode((int)HttpStatusCode.NoContent); 
        }

        private List<string> ValidateDto(IValidate dto) {
            if (dto is null) {
                return new List<string>() { GenericServiceResource.NullArgument };
            }

            return dto.ValidateData().ToList();
        }
    }
}
