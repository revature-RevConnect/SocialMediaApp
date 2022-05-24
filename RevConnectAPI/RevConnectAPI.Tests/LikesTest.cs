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
    public class LikeTest
    {

        [Fact]
        public async Task LikeController_GetLikes_GetAllLikes()

        {
            //Arrange
            var testing = new TestDB();
            var context = testing.CreateContextForInMemory();
            context.Likes.Add(new Like
            {
                likeID = 1,
                authID = 1,
                postID = 1,
                commentID = 1,//null
               

            });
            context.Likes.Add(new Like
            {
                likeID = 2,
                authID = 2,
                postID = 2,
                commentID = 2,//null
               

            });
        
            context.SaveChanges();

            //Act
            LikeController testController = new LikeController(context);
            var actionResult = await testController.GetLikes();//post

            //Assert
            List<Like> likes = actionResult.Value;

            Assert.Equal(2, likes.Count);
            var firstLike = likes[0];
            var secondlike = likes[1];

            Assert.Equal(1, firstLike.likeID);
            Assert.Equal(1, firstLike. authID );
            Assert.Equal(1, firstLike.postID);
            Assert.Equal(1, firstLike.commentID);

            Assert.Equal(2, secondLike.likeID);
            Assert.Equal(2, secondLike.authID);
            Assert.Equal(2, fsecondLike.postID);
            Assert.Equal(2, secondLike.commentID);
        

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
                userID = 1,
                postID = 1,
                commentID = 1,//null
               

            });
            context.Likes.Add(new Like
            {
                likeID = 2,
                userID = 2,
                postID = 2,
                commentID = 2,//null
               

            });
        
            context.SaveChanges();

            //Act
            LikeController testController = new LikeController(context);
            var actionResult = await testController.AddLikes();

            //Assert
            List<Like> likes = actionResult.Value;

            Assert.Equal(2, likes.Count);
            var firstLike = likes[0];
            var secondlike = likes[1];

            Assert.Equal(1, firstLike.likeID);
            Assert.Equal(1, firstLike.authID);
            Assert.Equal(1, firstLike.postID);
            Assert.Equal(1, firstLike.commentID);

            Assert.Equal(2, secondLike.likeID);
            Assert.Equal(2, secondLike.authID);
            Assert.Equal(2, fsecondLike.postID);
            Assert.Equal(2, secondLike.commentID);
        

        }
    }
}