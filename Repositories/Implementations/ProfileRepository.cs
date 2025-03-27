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

        public async Task<User?> GetByUsername(string username)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Username == username);
        }
    }
}
