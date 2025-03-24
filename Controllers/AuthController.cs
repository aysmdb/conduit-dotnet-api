using AutoMapper;
using conduit_dotnet_api.Models.Entities;
using conduit_dotnet_api.Models.Requests;
using conduit_dotnet_api.Models.Responses;
using conduit_dotnet_api.Repositories;
using conduit_dotnet_api.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using BCryptNet = BCrypt.Net.BCrypt;

namespace conduit_dotnet_api.Controllers
{
    [Route("api")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        private readonly IAuthService _authService;

        public AuthController(IMapper mapper, IUserRepository userRepository, IAuthService authService)
        {
            _mapper = mapper;
            _userRepository = userRepository;
            _authService = authService;
        }

        [HttpGet("users/login")]
        public IActionResult Login()
        {
            return Ok("hai");
        }

        [HttpPost("users")]
        public async Task<IActionResult> Register(RegistrationRequest request)
        {
            var token = _authService.GenerateToken(request.User.Email);
            request.User.Password = BCryptNet.HashPassword(request.User.Password);
            var user = _mapper.Map<User>(request);

            var newUser = await _userRepository.Create(user);
            var resp = _mapper.Map<UserResponse>(newUser);
            resp.User.Token = token;

            return Ok(resp);
        }

        [Authorize]
        [HttpGet("user")]
        public async Task<IActionResult> CurrentUser()
        {
            var email = _authService.GetEmail();
            if (email == null)
            {
                return Unauthorized();
            }
            var user = await _userRepository.GetByEmail(email);
            if (user == null)
            {
                return Unauthorized();
            }
            var resp = _mapper.Map<UserResponse>(user);
            return Ok(resp);
        }
    }
}
