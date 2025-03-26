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

        [HttpPost("users/login")]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            var user = await _userRepository.GetByEmail(request.User.Email);
            if (user == null)
            {
                return Unauthorized();
            }
            if (!BCryptNet.Verify(request.User.Password, user.Password))
            {
                return Unauthorized();
            }
            var token = _authService.GenerateToken(user.Id);
            var resp = _mapper.Map<UserResponse>(user);
            return Ok(resp);
        }

        [HttpPost("users")]
        public async Task<IActionResult> Register(RegistrationRequest request)
        {
            request.User.Password = BCryptNet.HashPassword(request.User.Password);
            var user = _mapper.Map<User>(request);

            var newUser = await _userRepository.Create(user);
            var token = _authService.GenerateToken(newUser.Id);
            var resp = _mapper.Map<UserResponse>(newUser);
            resp.User.Token = token;

            return Ok(resp);
        }

        [Authorize]
        [HttpGet("user")]
        public async Task<IActionResult> CurrentUser()
        {
            var id = _authService.GetId();
            if (id == null)
            {
                return Unauthorized();
            }
            var user = await _userRepository.GetById((int)id);
            if (user == null)
            {
                return Unauthorized();
            }
            var resp = _mapper.Map<UserResponse>(user);
            return Ok(resp);
        }
    }
}
