using Microsoft.Extensions.Logging;
using RevConnectAPI.Controllers;
using RevConnectAPI.Data.Models;
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
        private readonly ILogger<PostsController> _logger;

        [Fact]
        public async Task PostsController_PostTest()
        {
            //Arrange
            var testing = new TestDB();
            var context = testing.CreateContextForInMemory();

            var TestPost = new Post
            {
                postID = 1,
                title = "TestTitle",
                body = "TestBody",
                authID = "a"
            };



            //Act
            PostsController testController = new PostsController(_logger, context);
            await testController.Post(TestPost);//post
            var result = await testController.Get();
            //Assert
            List<Post> posts = result.Value;

            Assert.Equal(1, posts[0].postID);
            Assert.Equal("TestTitle", posts[0].title);
            Assert.Equal("TestBody", posts[0].body);
            Assert.Equal("a", posts[0].authID);

        }


        [Fact]
        public async Task PostsController_PostGetTest()
        {
            //Arrange
            var testing = new TestDB();
            var context = testing.CreateContextForInMemory();
            context.Posts.Add(new Post
            {
                postID = 1,
                title = "TestTitle",
                body = "TestBody",
                authID = "a",
            });
            context.SaveChanges();



            //Act
            PostsController testController = new PostsController(_logger, context);
            var result = await testController.Get();
            //Assert
            var posts = result.Value;

            Assert.Equal(1, posts[0].postID);
            Assert.Equal("TestTitle", posts[0].title);
            Assert.Equal("TestBody", posts[0].body);
            Assert.Equal("a", posts[0].authID);

        }
    }
}
