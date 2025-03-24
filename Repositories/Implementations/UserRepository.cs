using conduit_dotnet_api.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace conduit_dotnet_api.Repositories.Implementations
{
    public class UserRepository : IUserRepository
    {
        private readonly MyDbContext _context;

        public UserRepository(MyDbContext context)
        {
            _context = context;
        }

        public async Task<User> Create(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<User?> GetByEmail(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        }

        public Task<User> GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
