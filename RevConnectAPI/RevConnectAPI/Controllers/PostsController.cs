using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RevConnectAPI.Data.DataContext;
using RevConnectAPI.Data.Models;

namespace RevConnectAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PostsController : Controller
    {
        private readonly ILogger<PostsController> _logger;
        private readonly RevConnectContext _rc;

        public PostsController(ILogger<PostsController> logger, RevConnectContext rc)
        {
            _logger = logger;
            _rc = rc;
        }

        [HttpPost]
        public async Task<ActionResult<Post>> Post(Post post)
        {
            await _rc.AddRangeAsync(post);
            await _rc.SaveChangesAsync();
            return post;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<Post>>> Get(string id)
        {
            var posts = await _rc.Posts
                .Where(b => b.authID == id).ToListAsync();


            return posts.ToList();
        }
        [HttpGet("all")]
        public async Task<ActionResult<List<Post>>> Get()
        {
            var posts = await _rc.Posts.OrderByDescending(i => i.postID).ToListAsync();

            return posts.ToList();
        }
    }
}
