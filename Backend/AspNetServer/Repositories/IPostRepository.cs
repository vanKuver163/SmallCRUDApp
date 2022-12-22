using AspNetServer.Data;

namespace AspNetServer.Repositories
{
    public interface IPostRepository
    {
        Task<Post>GetPostAsync(int id);      
        Task<IEnumerable<Post>>GetPostsAsync();
        Task CreatePostAsync(Post post);
        Task UpdatePostAsync(Post post);
        Task DeletePostAsync(int id);
    }
}