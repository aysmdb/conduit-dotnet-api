using conduit_dotnet_api.Models.Entities;

namespace conduit_dotnet_api.Repositories
{
    public interface IProfileRepository
    {
        Task<User?> GetByUsername(string username);
    }
}
