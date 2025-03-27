using AutoMapper;
using conduit_dotnet_api.Models.Responses;
using conduit_dotnet_api.Repositories;
using conduit_dotnet_api.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace conduit_dotnet_api.Controllers
{
    [Route("api/profiles")]
    [ApiController]
    public class ProfileController : ControllerBase
    {
        private readonly IProfileRepository _profileRepository;
        private readonly IMapper _mapper;
        private readonly IAuthService _authService;

        public ProfileController(IProfileRepository profileRepository, IMapper mapper, IAuthService authService)
        {
            _profileRepository = profileRepository;
            _mapper = mapper;
            _authService = authService;
        }

        [HttpGet("{username}")]
        public async Task<IActionResult> GetProfile(string username)
        {
            var userId = _authService.GetId();
            var user = await _profileRepository.GetByUsername(username);
            if (user == null)
            {
                return NotFound();
            }
            var resp = _mapper.Map<ProfileResponse>(user);
            if (userId != null)
            {
                resp.Profile.Following = user.Follower != null && user.Follower.Any(f => f.Id == userId);
            }
            else
            {
                resp.Profile.Following = false;
            }
            
            return Ok(resp);
        }
    }
}
