using conduit_dotnet_api.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace conduit_dotnet_api.Repositories.Implementations
{
    public class ProfileRepository : IProfileRepository
    {
        private readonly MyDbContext _context;

        public ProfileRepository(MyDbContext context)
        {
            _context = context;
        }

        public async Task<User?> Follow(User user, User userToFollow)
        {
            if(user.Following == null)
            {
                user.Following =
                [
                    userToFollow
                ];
            }
            else
            {
                user.Following.Add(userToFollow);
            }

            if(userToFollow.Follower == null)
            {
                userToFollow.Follower =
                [
                    user
                ];
            } else
                userToFollow.Follower.Add(user);
            
            _context.Update(user);
            _context.Update(userToFollow);

            await _context.SaveChangesAsync();
            return userToFollow;
        }

        public async Task<User?> GetByUsername(string username)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Username == username);
        }
    }
}
