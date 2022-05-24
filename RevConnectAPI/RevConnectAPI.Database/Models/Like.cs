using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevConnectAPI.Data.Models
{
    public class Like
    {
        public int likeID { get; set; }
        public string authID { get; set; }
        public int? postID { get; set; }
        public int? commentID { get; set; }
    }
}
