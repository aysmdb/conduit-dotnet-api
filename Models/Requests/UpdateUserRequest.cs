namespace conduit_dotnet_api.Models.Requests
{
    public class UpdateUserRequest
    {
        public class UpdateRequest
        {
            public string Email { get; set; } = "";
            public string Password { get; set; } = "";
            public string Username { get; set; } = "";
            public string Bio { get; set; } = "";
            public string Image { get; set; } = "";
        }
    }
}
