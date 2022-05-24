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
    public class LikeTest
    {
        private readonly ILogger<LikesController> _logger;

        [Fact]
        public async Task LikeController_GetLikes_GetAllLikes()

        {
            //Arrange
            var testing = new TestDB();
            var context = testing.CreateContextForInMemory();
            context.Likes.Add(new Like
            {
                likeID = 1,
                authID = "",
                postID = 1,
                commentID = 1,//null
               

            });
            context.Likes.Add(new Like
            {
                likeID = 2,
                authID = "",
                postID = 1,
                commentID = 1,//null


            });
            context.SaveChanges();

            //Act
            LikesController testController = new LikesController(_logger ,context);
            var actionResult = await testController.GetPostLikesCount(1);//post

            //Assert
            List<Like> likes = actionResult.Value;

            Assert.Equal(2, likes.Count);
            var firstLike = likes[0];
            var secondLike = likes[1];

            Assert.Equal(1, firstLike.likeID);
            Assert.Equal("", firstLike. authID );
            Assert.Equal(1, firstLike.postID);
            Assert.Equal(1, firstLike.commentID);

            Assert.Equal(2, secondLike.likeID);
            Assert.Equal("", secondLike.authID);
            Assert.Equal(1, secondLike.postID);
            Assert.Equal(1, secondLike.commentID);
        

        }
        [Fact]
        public async Task LikeController_AddLikes_GetAllLikes()

        {
            //Arrange
            var testing = new TestDB();
            var context = testing.CreateContextForInMemory();
            context.Likes.Add(new Like
            {
                likeID = 1,
                authID = "",
                postID = 1,
                commentID = 0,//null


            });
            context.Likes.Add(new Like
            {
                likeID = 2,
                authID= "",
                postID = 2,
                commentID = 0,//null
            });
        
            context.SaveChanges();

            //Act
            LikesController testController = new LikesController(_logger,context);
            var actionResult = await testController.LikePost();

            //Assert
            List<Like> likes = actionResult.Value;

            Assert.Equal(2, likes.Count);
            var firstLike = likes[0];
            var secondLike = likes[1];

            Assert.Equal(1, firstLike.likeID);
            Assert.Equal("", firstLike.authID);
            Assert.Equal(1, firstLike.postID);
            Assert.Equal(1, firstLike.commentID);

            Assert.Equal(2, secondLike.likeID);
            Assert.Equal("", secondLike.authID);
            Assert.Equal(2, secondLike.postID);
            Assert.Equal(2, secondLike.commentID);
        

        }
    }
}