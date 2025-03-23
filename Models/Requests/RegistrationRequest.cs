namespace conduit_dotnet_api.Models.Requests
{
    public class RegistrationRequest
    {
        public required UserRequest User { get; set; }
        public class UserRequest
        {
            public string Email { get; set; } = "";
            public string Password { get; set; } = "";
            public string Username { get; set; } = "";
        }
    }
}
