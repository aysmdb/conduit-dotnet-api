using AutoMapper;
using conduit_dotnet_api.Models.Entities;
using conduit_dotnet_api.Models.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace conduit_dotnet_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMapper _mapper;

        public AuthController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpGet("login")]
        public IActionResult Login()
        {
            return Ok("hai");
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegistrationRequest request)
        {
            var user = _mapper.Map<User>(request);
            return Ok("hai");
        }
    }
}
