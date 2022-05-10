using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RevConnectAPI.Database.Models;

namespace RevConnectAPI.Database.DataAccess
{
    public class RevConnectContext:DbContext
    {
        public RevConnectContext(DbContextOptions options): base(options){ }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Like> Likes { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("RevConnect");
        }
    }
}
