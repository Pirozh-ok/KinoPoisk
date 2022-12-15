using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KinoPoisk.PresentationLayer.Controllers {
    [Route("api/[controller]/")]
    [ApiController]
    public class TokenController : ControllerBase {
        private ITokenService _tokenService;

        public TokenController(ITokenService tokenService) {
            _tokenService = tokenService;
        }

        [HttpGet("refresh")]
        [AllowAnonymous]
        public async Task<IActionResult> GetNewTokens([FromQuery]string jwtToken, [FromQuery]string resreshToken) {
            var result = await _tokenService.GetNewTokens(jwtToken, resreshToken);
            return result.Success ? Ok(result) : BadRequest(result);
        }
    }
}
