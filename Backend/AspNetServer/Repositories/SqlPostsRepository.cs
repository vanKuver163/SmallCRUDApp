using AspNetServer.Data;
using Microsoft.EntityFrameworkCore;

namespace AspNetServer.Repositories
{
    public class SqlPostsRepository : IPostRepository
    {
        protected readonly AppDbContext _db;
        public SqlPostsRepository(AppDbContext db) 
        {
            _db = db;
        }

        public async Task CreatePostAsync(Post post)
        {
            await _db.Posts.AddAsync(post);
            await _db.SaveChangesAsync();
        }

        public async Task DeletePostAsync(int id)
        {
            var postDelete = await _db.Posts.FindAsync(id);
            _db.Posts.Remove(postDelete);
            await _db.SaveChangesAsync();
        }

        public async Task<Post> GetPostAsync(int id)
        {
             return await _db.Posts.FirstOrDefaultAsync(post => post.PostId == id);
        }

        public async Task<IEnumerable<Post>> GetPostsAsync()
        {            
            return await _db.Posts.ToListAsync();
        }

        public async Task UpdatePostAsync(Post post)
        {
             _db.Posts.Update(post);            
            await _db.SaveChangesAsync();
        }
    }
}