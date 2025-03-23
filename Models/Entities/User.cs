using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace conduit_dotnet_api.Models.Entities
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public required string Username { get; set; }
        public required string Password { get; set; }
        public required string Email { get; set; }
        public string? Image { get; set; }
        public string? Bio { get; set; }
        public bool Demo { get; set; }

        public List<User>? Follower { get; set; }
        public List<User>? Following { get; set; }
        public List<Article>? Articles { get; set; }
        public List<Article>? Favorites { get; set; }

    }
}
