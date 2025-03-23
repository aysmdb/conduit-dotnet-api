using conduit_dotnet_api.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace conduit_dotnet_api
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Article> Articles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasIndex(e => e.Username).IsUnique();
            modelBuilder.Entity<User>()
                .HasIndex(e => e.Email).IsUnique();
            modelBuilder.Entity<User>().HasMany(e => e.Follower).WithMany()
                .UsingEntity(
                "UserFollower",
                l => l.HasOne(typeof(User)).WithMany().HasForeignKey("UserId").HasPrincipalKey(nameof(User.Id)),
                r => r.HasOne(typeof(User)).WithMany().HasForeignKey("FollowerId").HasPrincipalKey(nameof(User.Id)),
                j => j.HasKey("FollowerId", "UserId"));

            modelBuilder.Entity<User>().HasMany(e => e.Following).WithMany()
                .UsingEntity(
                "UserFollowing",
                l => l.HasOne(typeof(User)).WithMany().HasForeignKey("UserId").HasPrincipalKey(nameof(User.Id)),
                r => r.HasOne(typeof(User)).WithMany().HasForeignKey("FollowingId").HasPrincipalKey(nameof(User.Id)),
                j => j.HasKey("FollowingId", "UserId"));
            
            modelBuilder.Entity<Tag>()
                .HasIndex(e => e.Name).IsUnique();

            modelBuilder.Entity<Article>()
                .HasIndex(e => e.Slug).IsUnique();
            modelBuilder.Entity<Article>().HasOne(e => e.Author).WithMany(e => e.Articles).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Article>().HasMany(e => e.FavoriteBy).WithMany(e => e.Favorites)
                .UsingEntity(
                "UserFavorite");

            base.OnModelCreating(modelBuilder);
        }

    }
}
