using AutoMapper;
using conduit_dotnet_api.Models.Requests;
using conduit_dotnet_api.Models.Responses;
using conduit_dotnet_api.Repositories;
using conduit_dotnet_api.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace conduit_dotnet_api.Controllers
{
    [Route("api/profiles")]
    [ApiController]
    public class ProfileController : ControllerBase
    {
        private readonly IProfileRepository _profileRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IAuthService _authService;

        public ProfileController(IProfileRepository profileRepository, IMapper mapper, IAuthService authService, IUserRepository userRepository)
        {
            _profileRepository = profileRepository;
            _mapper = mapper;
            _authService = authService;
            _userRepository = userRepository;
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

        [HttpPost("{username}/follow")]
        [Authorize]
        public async Task<IActionResult> Follow([FromRoute] string username, [FromBody] FollowRequest request)
        {
            var userId = _authService.GetId();
            var user = await _userRepository.GetById((int)userId);
            var userToFollow = await _profileRepository.GetByUsername(username);
            if (user == null || userToFollow == null)
            {
                return NotFound();
            }
            
            var followedUser = await _profileRepository.Follow(user, userToFollow);
            var resp = _mapper.Map<ProfileResponse>(followedUser);
            resp.Profile.Following = followedUser.Follower != null && followedUser.Follower.Any(f => f.Id == userId);
            return Ok(resp);
        }
    }
}
