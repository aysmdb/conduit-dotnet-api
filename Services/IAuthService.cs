namespace conduit_dotnet_api.Services
{
    public interface IAuthService
    {
        string GenerateToken(string email);
    }
}
