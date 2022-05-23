using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RevConnectAPI.Data.DataContext;
using RevConnectAPI.Data.Models;

namespace RevConnectAPI.Controllers
{


    public class BlobConfig
{
    public string _connection { get; set; }
}

[Route("[controller]")]
[ApiController]
public class PhotosController : Controller
{

    public RevConnectContext _rc { get; set; }
    public BlobConfig _config { get; set; }
    public ILogger<PhotosController> _logger { get; set; }


    public PhotosController(BlobConfig config, RevConnectContext rc, ILogger<PhotosController> logger)

    {

        _config = config;
        _rc = rc;
        _logger = logger;
    }

    [HttpPost("images")]
    public async Task<ActionResult<User>> upload([FromQuery] string authID, IFormFile postedFile)
    {

        string path = $"https://dangagne.blob.core.windows.net/revconnect/{postedFile.FileName}";
        var user = await _rc.Users
                .Where(b => b.authID == authID).FirstAsync();
        user.profilePicture = path;
        await _rc.SaveChangesAsync();


        BlobContainerClient container = new BlobContainerClient(_config._connection, "revconnect");
        BlobClient blob = container.GetBlobClient(postedFile.FileName);
        await blob.UploadAsync(
            postedFile.OpenReadStream(),
            new BlobHttpHeaders
            { ContentType = postedFile.ContentType }
            );


        return user;


    }
}
}
