using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevConnectAPI.Database.Models
{
    //Dan wrote this User Model
    public class User
    {
        [Key]
        public int userID { get; set; }
        [Required]
        [MaxLength(256)]
        public string firstName { get; set; }
        [Required]
        [MaxLength(256)]
        public string lastName { get; set; }
        [Required]
        [MaxLength(256)]
        public string userName { get; set; }
        [Required]
        [MaxLength(256)]
        public string password { get; set; }
        public string? aboutMe { get; set; }
        public string profilePicture { get; set; }
        public List<Comment>? userComments { get; set; }
        public List<Post>? userPosts { get; set; }
        public List<Like>? userLikes { get; set; }

    }
}
