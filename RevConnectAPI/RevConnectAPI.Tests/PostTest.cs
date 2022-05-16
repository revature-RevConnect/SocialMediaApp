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
                userID = 10

            });
            context.SaveChanges();

            //Act
            PostController testController = new PostController(context);
            var actionResult = await testController.GetAllPosts();//post

            //Assert
            List<Post> posts = actionResult.Value;

            Assert.Equal(2, posts.Count);
            var firstPost = posts[0];
            var secondPost = posts[1];

            Assert.Equal(1, firstPost.postID);
            Assert.Equal("Testing Post Body", firstPost.body);
            Assert.Equal("05/12/2022", firstPost.date);
            Assert.Equal(1, firstPost.userID);

            Assert.Equal(2, secondPost.postID);
            Assert.Equal("Testing Post Body2", secondPost.body);
            Assert.Equal(10, secondPost.userID);


            // Assert.Equal(1, posts[0].postID);
            // Assert.Equal("Testing Post Body", posts[0].body);
            // Assert.Equal(1, posts[0].userID);
            // Assert.Equal(1, posts[1].userID);
            // Assert.Equal(2, posts.Count());


        }

        [Fact]
        public async Task PostController_UpdatePosts_GetAllPosts()

        {
            //Arrange
            var testing = new TestDB();
            var context = testing.CreateContextForInMemory();
            context.Posts.Update(new Post
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


        [Fact]
        public async Task PostController_AddPost()
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
            context.SaveChanges();

            //Act
            var postToAdd = new Post
            {
                postID = 2,
                body = "My newly created message",
                date = "05/12/2022",
                userID = 2,
            };

            PostController testController = new PostController(context);
            var actionResult = await testController.AddPost(postToAdd);//post

            //Assert
            List<Post> posts = actionResult.Value;

            Assert.Equal(2, posts.Count);
            var firstPost = posts[0];
            var secondPost = posts[1];

            Assert.Equal(1, firstPost.postID);
            Assert.Equal("Testing Post Body", firstPost.body);
            Assert.Equal("05/12/2022", firstPost.date);
            Assert.Equal(1, firstPost.userID);

            Assert.Equal(2, secondPost.postID);
            Assert.Equal("My newly created message", secondPost.body);
            Assert.Equal(DateTime.Now.ToString(), secondPost.date);
            Assert.Equal(2, secondPost.userID);


            // Assert.Equal(1, posts[0].postID);
            // Assert.Equal("Testing Post Body", posts[0].body);
            // Assert.Equal(1, posts[0].userID);
            // Assert.Equal(1, posts[1].userID);
            // Assert.Equal(2, posts.Count());


        }

        [Fact]
        public async Task PostController_UpdatePost()
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
                postID = 10,
                body = "Testing Post Body 10",
                date = "05/12/2022",
                image = "image-before",
                userID = 1,
            });

            context.SaveChanges();

            //Act
            var postToChange = new Post
            {
                postID = 10,
                body = "My newly updated message",
                date = "05/12/2022",
                image = "image-after",
                userID = 2,
            };

            PostController testController = new PostController(context);
            var actionResult = await testController.UpdatePost(postToChange);//post

            //Assert
            List<Post> posts = actionResult.Value;

            Assert.Equal(2, posts.Count);
            var firstPost = posts[0];
            var secondPost = posts[1];

            Assert.Equal(1, firstPost.postID);
            Assert.Equal("Testing Post Body", firstPost.body);
            Assert.Equal("05/12/2022", firstPost.date);
            Assert.Equal(1, firstPost.userID);

            //unchanged values      
            Assert.Equal(10, secondPost.postID);
            Assert.Equal(1, secondPost.userID);

            //updated values
            Assert.Equal("My newly updated message", secondPost.body);
            Assert.Equal("image-after", secondPost.image);
            Assert.Equal(DateTime.Now.ToString(), secondPost.date);
        }
        [Fact]
        public async Task PostController_DeletPosts_GetAllPosts()

        {
            //Arrange
            var testing = new TestDB();
            var context = testing.CreateContextForInMemory();
            context.Posts.Add(new Post
            {
                postID = 42,
                body = "Testing Post Body",
                date = "05/12/2022",
                userID = 1,

            });
            context.Posts.Add(new Post
            {
                postID = 2,
                body = "Testing Post Body2",
                date = "05/12/2022",
                userID = 20

            });
            context.SaveChanges();

            //Act
            PostController testController = new PostController(context);
            var actionResult = await testController.DeletePost(42);//post

            //Assert
            List<Post> posts = actionResult.Value;

            Assert.Equal(1, posts.Count);
            var firstPost = posts[0];

            Assert.Equal(2, firstPost.postID);
            Assert.Equal("Testing Post Body2", firstPost.body);
        }
    }