using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RevConnectAPI.Data.DataContext;
using RevConnectAPI.Data.Models;

namespace RevConnectAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : Controller
    {
        private readonly ILogger<UsersController> _logger;
        private readonly RevConnectContext _rc;

        public UsersController(ILogger<UsersController> logger, RevConnectContext rc)
        {
            _logger = logger;
            _rc = rc;
        }

        [HttpPost]
        public async Task<ActionResult<User>> Post(User user)
        {
            await _rc.AddRangeAsync(user);
            await _rc.SaveChangesAsync();
            return user;
        }

        [HttpGet("{authID}")]
        public async Task<ActionResult<User>> Login(string authID)
        {
            var activeUser = await _rc.Users
                .Where(b => b.authID == authID).FirstAsync();

            return activeUser;

        }

        [HttpPut("picture")]
        public async Task<ActionResult<User>> ChangePicture(User user)
        {
            var newUser = await _rc.Users
                        .Where(b => b.authID == user.authID).FirstAsync();
            newUser.profilePicture = user.profilePicture;
            await _rc.SaveChangesAsync();

            return new ContentResult() { StatusCode = 200 };
        }

        [HttpPut("username")]
        public async Task<ActionResult<User>> ChangeUserName(User user)
        {
            var newUser = await _rc.Users
                        .Where(b => b.authID == user.authID).FirstAsync();
            newUser.name = user.name;
            await _rc.SaveChangesAsync();

            return new ContentResult() { StatusCode = 200 };
        }

        [HttpPut("aboutMe")]
        public async Task<ActionResult<User>> ChangeAboutMe(User user)
        {
            var newUser = await _rc.Users
                        .Where(b => b.authID == user.authID).FirstAsync();
            newUser.aboutMe = user.aboutMe;
            await _rc.SaveChangesAsync();

            return new ContentResult() { StatusCode = 200 };
        }

        [HttpPut("phone")]
        public async Task<ActionResult<User>> ChangePhoneNumber(User user)
        {
            var newUser = await _rc.Users
                        .Where(b => b.authID == user.authID).FirstAsync();
            newUser.aboutMe = user.aboutMe;
            await _rc.SaveChangesAsync();

            return new ContentResult() { StatusCode = 200 };
        }

        [HttpPut("email")]
        public async Task<ActionResult<User>> ChangeEmail(User user)
        {
            var newUser = await _rc.Users
                        .Where(b => b.authID == user.authID).FirstAsync();
            newUser.aboutMe = user.aboutMe;
            await _rc.SaveChangesAsync();

            return new ContentResult() { StatusCode = 200 };
        }

        [HttpPut("address")]
        public async Task<ActionResult<User>> ChangeAddress(User user)
        {
            var newUser = await _rc.Users
                        .Where(b => b.authID == user.authID).FirstAsync();
            newUser.aboutMe = user.aboutMe;
            await _rc.SaveChangesAsync();

            return new ContentResult() { StatusCode = 200 };
        }
    }

}