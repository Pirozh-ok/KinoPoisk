using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;

namespace KinoPoisk.PresentationLayer.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase {
        protected string? GetAuthUserId() => User.Claims.FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Jti)?.Value;
    }
}
