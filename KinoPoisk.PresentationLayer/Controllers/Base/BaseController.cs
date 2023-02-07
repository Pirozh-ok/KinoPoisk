using KinoPoisk.DataAccessLayer;
using KinoPoisk.DomainLayer;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using static KinoPoisk.DomainLayer.DTOs.ApiResponseDto;

namespace KinoPoisk.PresentationLayer.Controllers.Base
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        protected string? GetAuthUserId() => User.Claims
            .FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Jti)?.Value;
        protected bool IsAdministratorRequest() => User.IsInRole(Constants.NameRoleAdmin);

        protected OkObjectResult GetOkResponseResult(string message) {
            return Ok(new OkResponseResultDto {
                Message = message
            });
        }

        protected OkObjectResult GetOkResponseResult<T>(string message, T data) {
            return Ok(new OkResponseResultModel<T> {
                Message = message,
                Data = data
            });
        }

        protected OkObjectResult GetOkResponseResult(ServiceResult result) {
            return GetOkResponseResult(result.);
        }

        protected OkObjectResult GetOkResponseResult<T>(ServiceResult<T> result) {
            return GetOkResponseResult(result.Message, result.Data);
        }

        protected BadRequestObjectResult GetErrorResponseResult(ServiceResult result) {
            return BadRequest(new ErrorResponseResultModel {
                Error = result.Message,
                Details = result.ErrorDetails
            });
        }

        protected StatusCodeResult GetForbiddenResponseResult() {
            return StatusCode(StatusCodes.Status403Forbidden);
        }
    }
}
