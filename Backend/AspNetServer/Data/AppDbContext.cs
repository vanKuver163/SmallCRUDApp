using Microsoft.EntityFrameworkCore;

namespace AspNetServer.Data
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}      
        public DbSet<Post> Posts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
       {
            Post[] postsToSeed = new Post[6];
            for(int i = 1; i <=6; i++)
            {
                postsToSeed[i - 1] = new Post
                {
                    PostId = i,
                    Title = $"Post {i}",
                    Content = $"This is post {i}."
                };
            }
            modelBuilder.Entity<Post>().HasData(data: postsToSeed);
       }

    }
}