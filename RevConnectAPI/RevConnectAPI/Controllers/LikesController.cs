using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RevConnectAPI.Data.DataContext;
using RevConnectAPI.Data.Models;

namespace RevConnectAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LikesController : Controller
    {
        private readonly ILogger<LikesController> _logger;
        private readonly RevConnectContext _rc;

        public LikesController(ILogger<LikesController> logger, RevConnectContext rc)
        {
            _logger = logger;
            _rc = rc;
        }
        [HttpGet("{postID}")]
        public async Task<ActionResult<List<Like>>> GetPostLikesCount(int postID)
        {
            var likes = await _rc.Likes
                    .Where(b => b.postID == postID).ToListAsync();
            return likes.ToList();
        }
        [HttpPost("post")]
        public async Task<ActionResult<Like>> LikePost(Like newLike)
        {
            await _rc.Likes.AddRangeAsync(newLike);

            await _rc.SaveChangesAsync();
            return newLike;
        }

        [HttpPost("comment")]
        public async Task<ActionResult<Like>> LikeComment(Like newLike)
        {
            await _rc.Likes.AddRangeAsync(newLike);
            await _rc.SaveChangesAsync();
            return newLike;
        }
    }
}
