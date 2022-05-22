using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RevConnectAPI.Data.DataContext;
using RevConnectAPI.Data.Models;

namespace RevConnectAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CommentsController : Controller
    {

        private readonly ILogger<CommentsController> _logger;
        private readonly RevConnectContext _rc;

        public CommentsController(ILogger<CommentsController> logger, RevConnectContext rc)
        {
            _logger = logger;
            _rc = rc;
        }

        [HttpPost]
        public async Task<ActionResult<Comment>> Post(Comment comment)
        {
            await _rc.AddRangeAsync(comment);
            await _rc.SaveChangesAsync();
            return comment;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<Comment>>> Get(string id)
        {
            var comments = await _rc.Comments
                .Where(b => b.authID == id).ToListAsync();


            return comments.ToList();
        }
        [HttpGet("all")]
        public async Task<ActionResult<List<Comment>>> Get()
        {
            var comments = await _rc.Comments.ToListAsync();

            return comments.ToList();
        }

    }
}