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

        [Fact]
        public async Task PostController_GetPosts_GetAllPosts()

        {
            //Arrange
            var testing = new TestDB();
            var context = testing.CreateContextForInMemory();
            context.Posts.Add(new Post
            {
                postID = 1,
                userID = 1,
                body = "Testing Post Body",
                date = "05/12/2022",
                image = ""//how to pass image to test and comments and others
                postComments = " ",
                postLike = "",

            });
            context.Posts.Add(new Post
            {
                postID = 2,
                userID = 2,
                body = "Testing Post Body",
                date = "05/22/2022",
                image = ""//how to pass image to test and comments and others
                postComments = " ",
                postLike = "",

            });
            context.SaveChanges();

            //Act
            PostController testController = new PostController(context);
            var actionResult = await testController.GetPosts();//post

            //Assert
            List<Post> posts = actionResult.Value;

            Assert.Equal(2, posts.Count);
            var firstPost = posts[0];
            var secondPost = posts[1];

            Assert.Equal(1, firstPost.postID);
            Assert.Equal(1, firstPost.userID);
            Assert.Equal("Testing Post Body", firstPost.body);
            Assert.Equal("05/12/2022", firstPost.date);
            Assert.Equal("Image", firstPost.Image);
            Assert.Equal("Poste Comments", firstPost.postComments);
            Assert.Equal("Post Like", firstPost.postLike);

            Assert.Equal(2, secondPost.postID);
            Assert.Equal(2, secondPost.userID);
            Assert.Equal("Testing Post Body", secondPost.body);
            Assert.Equal("05/12/2022", secondPost.date);
            Assert.Equal("Image", secondPost.Image);
            Assert.Equal("Poste Comments", secondPost.postComments);
            Assert.Equal("Post Like", secondPost.postLike);


        }


        [Fact]
        public async Task PostController_AddPost_GetAllPosts()
        {
            //Arrange
            var testing = new TestDB();
            var context = testing.CreateContextForInMemory();
            context.Posts.Add(new Post
            {
                postID = 1,
                userID = 1,
                body = "Testing Post Body",
                date = "05/12/2022",
                image = "",//how to pass image to test and comments and others
                postComments = " ",
                postLike = "",

            });
            context.Posts.Add(new Post
            {
                postID = 2,
                userID = 2,
                body = "Testing Post Body",
                date = "05/22/2022",
                image = "",//how to pass image to test and comments and others
                postComments = " ",
                postLike = "",

            });
            context.SaveChanges();

            //Act
            PostController testController = new PostController(context);
            var actionResult = await testController.AddPosts();//post

            //Assert
            List<Post> posts = actionResult.Value;

            Assert.Equal(2, posts.Count);
            var firstPost = posts[0];
            var secondPost = posts[1];

            Assert.Equal(1, firstPost.postID);
            Assert.Equal(1, firstPost.userID);
            Assert.Equal("Testing Post Body", firstPost.body);
            Assert.Equal("05/12/2022", firstPost.date);
            Assert.Equal("Image", firstPost.Image);
            Assert.Equal("Poste Comments", firstPost.postComments);
            Assert.Equal("Post Like", firstPost.postLike);

            Assert.Equal(2, secondPost.postID);
            Assert.Equal(2, secondPost.userID);
            Assert.Equal("Testing Post Body", secondPost.body);
            Assert.Equal("05/12/2022", secondPost.date);
            Assert.Equal("Image", secondPost.Image);
            Assert.Equal("Poste Comments", secondPost.postComments);
            Assert.Equal("Post Like", secondPost.postLike);

        }

        [Fact]
        public async Task PostController_UpdatePost_GetAllPosts()
        {
            //Arrange
            var testing = new TestDB();
            var context = testing.CreateContextForInMemory();
            context.Posts.Add(new Post
            {
                postID = 1,
                userID = 1,
                body = "Testing Post Body",
                date = "05/12/2022",
                image = "",//how to pass image to test and comments and others
                postComments = "Test Post Comment",
                postLike = "Test post likes",

            });
            context.Posts.Add(new Post
            {
                postID = 2,
                userID = 2,
                body = "Testing Post Body",
                date = "05/22/2022",
                image = "",//how to pass image to test and comments and others
                postComments = "Test post comments ",
                postLike = "Test post likes",

            });
            context.SaveChanges();

            //Act
            PostController testController = new PostController(context);
            var actionResult = await testController.UpdatePosts();//post

            //Assert
            List<Post> posts = actionResult.Value;

            Assert.Equal(2, posts.Count);
            var firstPost = posts[0];
            var secondPost = posts[1];

            Assert.Equal(1, firstPost.postID);
            Assert.Equal(1, firstPost.userID);
            Assert.Equal("Testing Post Body", firstPost.body);
            Assert.Equal("05/12/2022", firstPost.date);
            Assert.Equal("Image", firstPost.Image);
            Assert.Equal("Poste Comments", firstPost.postComments);
            Assert.Equal("Post Like", firstPost.postLike);

            Assert.Equal(2, secondPost.postID);
            Assert.Equal(2, secondPost.userID);
            Assert.Equal("Testing Post Body", secondPost.body);
            Assert.Equal("05/12/2022", secondPost.date);
            Assert.Equal("Image", secondPost.Image);
            Assert.Equal("Poste Comments", secondPost.postComments);
            Assert.Equal("Post Like", secondPost.postLike);


        }
        [Fact]
        public async Task PostController_DeletPosts_GetAllPosts()

        {
            //Arrange
            var testing = new TestDB();
            var context = testing.CreateContextForInMemory();
            context.Posts.Add(new Post
            {

                postID = 1,
                userID = 1,
                body = "Testing Post Body",
                date = "05/12/2022",
                image = "",//how to pass image to test and comments and others
                postComments = "Test Post Comment",
                postLike = "Test post likes",

            });
            context.Posts.Add(new Post
            {
                postID = 2,
                userID = 2,
                body = "Testing Post Body",
                date = "05/22/2022",
                image = "",//how to pass image to test and comments and others
                postComments = "Test post comments ",
                postLike = "Test post likes",

            });
            context.SaveChanges();

            //Act
            PostsController testController = new PostsController(context);
            var actionResult = await testController.DeletePosts();//post

            //Assert
            List<Post> posts = actionResult.Value;

            Assert.Equal(2, posts.Count);
            var firstPost = posts[0];
            var secondPost = posts[1];

            Assert.Equal(1, firstPost.postID);
            Assert.Equal(1, firstPost.userID);
            Assert.Equal("Testing Post Body", firstPost.body);
            Assert.Equal("05/12/2022", firstPost.date);
            Assert.Equal("Image", firstPost.Image);
            Assert.Equal("Poste Comments", firstPost.postComments);
            Assert.Equal("Post Like", firstPost.postLike);

            Assert.Equal(2, secondPost.postID);
            Assert.Equal(2, secondPost.userID);
            Assert.Equal("Testing Post Body", secondPost.body);
            Assert.Equal("05/12/2022", secondPost.date);
            Assert.Equal("Image", secondPost.Image);
            Assert.Equal("Poste Comments", secondPost.postComments);
            Assert.Equal("Post Like", secondPost.postLike);
        }


    }
}

