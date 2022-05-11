using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevConnectAPI.Database.Models
{
    public class Post
    {
        [Key]
        public int postID { get; set; }
        public string body { get; set; }
        [MaxLength(256)]
        public string date { get; set; }
        public string? image { get; set; }
        public List<Comment>? postComments { get; set; }
        public List<Like>? postLikes { get; set; }

    }
}
