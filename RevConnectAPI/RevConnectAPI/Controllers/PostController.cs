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

    }
}
