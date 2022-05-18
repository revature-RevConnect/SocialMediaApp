using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevConnectAPI.Data.Models
{
    public class User
    {
        public int userID { get; set; }
        public string authID { get; set; }
        public string? name { get; set; }
        public string? email { get; set; }
        public string? profilePicture { get; set; }
        public string? aboutMe { get; set; }
        public string? phone { get; set; }
        public string? address { get; set; }
        public string? linkedin { get; set; }
        public string? twitter { get; set; }
        public string? github { get; set; }
        public bool active { get; set; }
    }
}
