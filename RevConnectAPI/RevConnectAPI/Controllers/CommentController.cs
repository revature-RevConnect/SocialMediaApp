using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RevConnectAPI.Database.DataAccess;
using RevConnectAPI.Database.Models;

namespace RevConnectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        // fields
        private readonly RevConnectContext _dataContext;

        // Constructor
        public CommentController(RevConnectContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpGet]
        public async Task<ActionResult<List<Comment>>> GetComments()
        {
            return await _dataContext.Comments.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<List<Comment>>> AddComment(Comment comment)
        {
            comment.date = DateTime.Now.ToString();
            _dataContext.Comments.Add(comment);
            await _dataContext.SaveChangesAsync();

            return Ok(await _dataContext.Comments.ToListAsync());
        }

        [HttpPut("{commentId}")]
        public async Task<ActionResult<List<Comment>>> UpdatePost(Comment comment)
        {
            var dbComment = await _dataContext.Comments.FindAsync(comment.commentID);
            if (dbComment == null)
                return BadRequest("Comment not found.");

            // Update post's body, and date
            dbComment.body = comment.body;
            dbComment.date = DateTime.Now.ToString();

            await _dataContext.SaveChangesAsync();

            return Ok(await _dataContext.Comments.ToListAsync());
        }

        [HttpDelete("{commentId}")]
        public async Task<ActionResult<List<Post>>> DeletePost(int commentId)
        {
            var dbComment = await _dataContext.Comments.FindAsync(commentId);
            if (dbComment == null)
                return BadRequest("Comment not found.");

            // Remove acquired post
            _dataContext.Comments.Remove(dbComment);
            await _dataContext.SaveChangesAsync();

            return Ok(await _dataContext.Comments.ToListAsync());
        }
    }
}
