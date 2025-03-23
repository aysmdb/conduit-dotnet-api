using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace conduit_dotnet_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        [HttpGet("login")]
        public IActionResult Login()
        {
            return Ok("hai");
        }
    }
}
