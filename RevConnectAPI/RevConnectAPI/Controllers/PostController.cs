using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RevConnectAPI.Database.DataAccess;
using RevConnectAPI.Database.Models;

namespace RevConnectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        // RevConnectContext field
        private readonly RevConnectContext _dataContext;
        // Constructor
        public PostController(RevConnectContext dataContext)
        {
            _dataContext = dataContext;
        }

        // Methods
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<List<Post>>> GetAllPosts()
        {
            return await _dataContext.Posts.ToListAsync();
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<List<Post>>> AddPost(Post post)
        {
            post.date = DateTime.Now.ToString();
            _dataContext.Posts.Add(post);
            await _dataContext.SaveChangesAsync();

            return Ok(await _dataContext.Posts.ToListAsync());
        }

        [HttpPut("{postId}")]
        [Authorize]
        public async Task<ActionResult<List<Post>>> UpdatePost(Post post)
        {
            var dbPost = await _dataContext.Posts.FindAsync(post.postID);
            if (dbPost == null)
                return BadRequest("Post not found.");

            // Update post's body, image, and date
            dbPost.body = post.body;
            dbPost.image = post.image;
            dbPost.date = DateTime.Now.ToString();

            await _dataContext.SaveChangesAsync();

            return Ok(await _dataContext.Posts.ToListAsync());
        }

        [HttpDelete("{postId}")]
        [Authorize]
        public async Task<ActionResult<List<Post>>> DeletePost(int postId)
        {
            var dbPost = await _dataContext.Posts.FindAsync(postId);
            if (dbPost == null)
                return BadRequest("Post not found.");

            // Remove acquired post
            _dataContext.Posts.Remove(dbPost);
            await _dataContext.SaveChangesAsync();

            return Ok(await _dataContext.Posts.ToListAsync());
        }
    }
}
