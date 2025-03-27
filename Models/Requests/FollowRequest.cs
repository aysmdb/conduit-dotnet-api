namespace conduit_dotnet_api.Models.Requests
{
    public class FollowRequest
    {
        public UserFollow User { get; set; } = new UserFollow();
        public class UserFollow
        {
            public string Email { get; set; } = "";
        }
    }
}
