using AspNetServer.Repositories;
using Microsoft.AspNetCore.Mvc;
using AspNetServer.Data;

namespace AspNetServer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PostsController : ControllerBase
    {
        private readonly IPostRepository repository ;

        public PostsController(IPostRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public async Task<IEnumerable<Post>> GetItemsAsync()
        {
            var posts = await repository.GetPostsAsync();
            return posts;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<Post>>GetPostAsync(int id)
        {
            var post = await repository.GetPostAsync(id);
            if(post == null)
            {
                return NotFound();
            }
            return post;
        }

        [HttpPost]
        public async Task<ActionResult>CreatePostAsync(Post post)
        {
            await repository.CreatePostAsync(post);
            return NoContent();
        }

        [HttpPut]             
        public async Task<ActionResult>UpdatePostAsync(Post post)
        {                      
            await repository.UpdatePostAsync(post);
            return NoContent();
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult>DeletePostAsync(int id)
        {           
            await repository.DeletePostAsync(id);
            return NoContent();
        }
    }
}