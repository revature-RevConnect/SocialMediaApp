using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevConnectAPI.Database.Models
{
    //Dan wrote this Comment Model
    public class Comment
    {
        [Key]
        public int commentID { get; set; }
        public string body { get; set; }
        public string date { get; set; }
        public List<Like>? commentLikes { get; set; }
        [ForeignKey("Post")]
        public int postID { get; set; }
        [ForeignKey("User")]
        public int userID { get; set; }



    }
}
