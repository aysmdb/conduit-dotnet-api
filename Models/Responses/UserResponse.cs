namespace conduit_dotnet_api.Models.Responses
{
    public class UserResponse
    {
        public Response User { get; set; } = new Response();
        public class Response
        {
            public string Email { get; set; } = "";
            public string Token { get; set; } = "";
            public string Username { get; set; } = "";
            public string Bio { get; set; } = "";
            public string Image { get; set; } = "";
        }
    }
}
