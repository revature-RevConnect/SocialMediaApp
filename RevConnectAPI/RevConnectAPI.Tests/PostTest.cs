using RevConnectAPI.Controllers;
using RevConnectAPI.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace RevConnectAPI.Tests
{
    public class PostTest
    {
        //Diego Wrote this Get Test for Post Controller
        /**NOT DONE Add Comment and Likes Assert Test **/
        [Fact]
        public async Task PostController_GetPosts_GetAllPosts()
        {
            //Arrange
            var testing = new TestDB();
            var context = testing.CreateContextForInMemory();
            context.Posts.Add(new Post
            {
                postID = 1,
                body = "Testing Post Body",
                date = "05/12/2022",
                userID = 1,

            });
            context.Posts.Add(new Post
            {
                postID = 2,
                body = "Testing Post Body2",
                date = "05/12/2022",
                userID = 1

            });
            context.SaveChanges();

            //Act
            PostController testController = new PostController(context);
            var posts = await testController.GetAllPosts();
            var posts1 = posts.Value;

            //Assert
            Assert.Equal(1, posts1[0].postID);
            Assert.Equal("Testing Post Body", posts1[0].body);
            Assert.Equal(1, posts1[0].userID);
            Assert.Equal(1, posts1[1].userID);
            Assert.Equal(2, posts1.Count());


        }
    }
}
