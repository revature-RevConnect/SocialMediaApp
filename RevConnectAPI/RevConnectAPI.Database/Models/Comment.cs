using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevConnectAPI.Data.Models
{
    public class Comment
    {
        public int commentID { get; set; }
        public string? body { get; set; }
        public string authID { get; set; }
        public int? postID { get; set; }
        public List<Like>? commentLikes { get; set; }
    }
}
