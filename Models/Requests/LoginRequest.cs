namespace conduit_dotnet_api.Models.Requests
{
    public class LoginRequest
    {
        public UserRequest User { get; set; } = new UserRequest();
        public class UserRequest
        {
            public string Email { get; set; } = "";
            public string Password { get; set; } = "";
        }
    }
}
