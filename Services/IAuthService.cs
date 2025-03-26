namespace conduit_dotnet_api.Services
{
    public interface IAuthService
    {
        string GenerateToken(int sub);
        string? GetEmail();
        int? GetId();
    }
}
