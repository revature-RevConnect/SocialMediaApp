using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevConnectAPI.Data.Models
{
    public class Post
    {
        public int postID { get; set; }
        public string? title { get; set; }
        public string? body { get; set; }
        public string authID { get; set; }
        public List<Like>? postLikes { get; set; }
        public List<Comment>? postComments { get; set; }

    }
}