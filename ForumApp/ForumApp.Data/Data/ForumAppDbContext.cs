using ForumApp.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace ForumApp.Data
{
    public class ForumAppDbContext : DbContext
    {
        public ForumAppDbContext(DbContextOptions<ForumAppDbContext> options)
            : base(options)
        {

        }

        private Post FirstPost { get; set; } = null!;

        private Post SecondPost { get; set; } = null!;

        private Post ThirdPost { get; set; } = null!;

        private Post FourthPost { get; set; } = null!;

        public DbSet<Post> Posts { get; init; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            SeedPosts();
            modelBuilder.Entity<Post>()
                .HasData(FirstPost, SecondPost, ThirdPost, FourthPost);

            base.OnModelCreating(modelBuilder);
        }

        private void SeedPosts()
        {
            FirstPost = new Post()
            {
                Id = 1,
                Title = "My first post",
                Content = "My first post will be about performing CRUD operations in MVC. It's so much fun!"
            };

            SecondPost = new Post()
            {
                Id = 2,
                Title = "My second post",
                Content = "This is my second post. CRUD operations in MVC are getting more and more interesting!"
            };

            ThirdPost = new Post()
            {
                Id = 3,
                Title = "My third post",
                Content = "Hello there! I'm getting better and better with the CRUD operations in MVC. Stay tuned!"
            };

            FourthPost = new Post()
            {
                Id = 4,
                Title = "My Fourth post",
                Content = "Test test!"
            };
        }
    }
}

