namespace conduit_dotnet_api.Models.Responses
{
    public class ProfileResponse
    {
        public ProfileResp Profile { get; set; } = new ProfileResp();
        public class ProfileResp
        {
            public string Username { get; set; } = "";
            public string Bio { get; set; } = "";
            public string Image { get; set; } = "";
            public bool Following { get; set; }
        }
    }
}
