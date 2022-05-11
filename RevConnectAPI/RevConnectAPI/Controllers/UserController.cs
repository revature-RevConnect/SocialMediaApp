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
    public class UserController : ControllerBase
    {
        // RevConnectContext field
        private readonly RevConnectContext _dataContext;
        // Constructor
        public UserController(RevConnectContext dataContext)
        {
            _dataContext = dataContext;
        }

        // Methods
        [HttpGet]
        public async Task<ActionResult<List<User>>> GetUsers()
        {
            return await _dataContext.Users.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<List<User>>> AddUser(User user)
        {
            _dataContext.Users.Add(user);
            await _dataContext.SaveChangesAsync();

            return Ok(await _dataContext.Users.ToListAsync());
        }
    }
}
