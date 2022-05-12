using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevConnectAPI.Database.Models
{
    //Dan wrote this Like Model
    public class Like
    {
        [Key]
        public int likeID { get; set; }
        [ForeignKey("User")]
        public int userID { get; set; }
        [ForeignKey("Post")]
        public int? postID { get; set; }
        [ForeignKey("Comment")]
        public int? commentID { get; set; }
    }
}
