using conduit_dotnet_api.Models.Entities;

namespace conduit_dotnet_api.Repositories
{
    public interface IUserRepository
    {
        Task<User> Create(User user);
        Task<User> GetByEmail(string email);
        Task<User> GetById(int id);
    }
}
