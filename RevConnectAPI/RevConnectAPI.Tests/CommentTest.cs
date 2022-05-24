//using RevConnectAPI.Controllers;
//using RevConnectAPI.Database.Models;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Xunit;

//namespace RevConnectAPI.Tests
//{
//    public class CommentTest
//    {

//        [Fact]
//        public async Task CommentController_GetComments_GetAllComments()

//        {
//            //Arrange
//            var testing = new TestDB();
//            var context = testing.CreateContextForInMemory();
//            context.Comments.Add(new Comment
//           {
//                commentID = 1,
//                body = "Comment body",
//                date = "5/224/2022",
//                commentLikes = 30,
//                postID = 1,
//                userID = 1,
                

//             });
//            context.Comments.Add(new Comment
//            {
//                commentID = 2,
//                body = "Comment body",
//                date = "5/224/2022",
//                commentLikes = 300,
//                postID = 2,
//                userID = 2,
                

//             });
  
//            context.SaveChanges();

//            //Act
//            CommentController testController = new CommentController(context);
//            var actionResult = await testController.GetComments();

//            //Assert
//            List<Comment> comments= actionResult.Value;

//            Assert.Equal(2, comments.Count);
//            var firstComment = comment[0];
//            var secondComment = comment[1];

//            Assert.Equal(1, firstComment.commentID);
//            Assert.Equal("Body", firstComment.body);
//            Assert.Equal("date", firstComment.date);
//            Assert.Equal("Comment likes", firstComment.commentLikes);
//            Assert.Equal("PassWord", firstComment.postID);
//            Assert.Equal("peofilePicture", firstComment.userID);

//            Assert.Equal(2, secondComment.commentID);
//            Assert.Equal("Body", secondComment.body);
//            Assert.Equal("date", secondComment.date);
//            Assert.Equal("Comment likes", secondComment.commentLikes);
//            Assert.Equal("PassWord", secondComment.postID);
//            Assert.Equal("peofilePicture", secondComment.userID);  

          

//        }          
//        [Fact]
//        public async Task CommentController_AddComments_GetAllComments()

//        {
//            //Arrange
//            var testing = new TestDB();
//            var context = testing.CreateContextForInMemory();
//            context.Comments.Add(new Comment
//           {
//                commentID = 1,
//                body = "Comment body",
//                date = "5/224/2022",
//                commenyLikes = 30,
//                postID = 1,
//                userID = 1,
                

//             });
//            context.Comments.Add(new Comment
//            {
//                commentID = 2,
//                body = "Comment body",
//                date = "5/224/2022",
//                commentLikes = 300,
//                postID = 2,
//                userID = 2,
                

//             });
  
//            context.SaveChanges();

//            //Act
//            CommentController testController = new CommentController(context);
//            var actionResult = await testController.AddComment();

//            //Assert
//            List<Comment> comments= actionResult.Value;

//            Assert.Equal(2, comments.Count);
//            var firstComment = comments[0];
//            var secondComment = comments[1];

//            Assert.Equal(1, firstComment.commentID);
//            Assert.Equal("Body", firstComment.body);
//            Assert.Equal("date", firstComment.date);
//            Assert.Equal("Comment likes", firstComment.commentLikes);
//            Assert.Equal("PassWord", firstComment.postID);
//            Assert.Equal("peofilePicture", firstComment.userID);

//            Assert.Equal(2, secondComment.commentID);
//            Assert.Equal("Body", secondComment.body);
//            Assert.Equal("date", secondComment.date);
//            Assert.Equal("Comment likes", secondComment.commentLikes);
//            Assert.Equal("PassWord", secondComment.postID);
//            Assert.Equal("peofilePicture", secondComment.userID);  

          

//        } 
//              [Fact]
//        public async Task CommentController_DeletComments_GetAllComments()

//        {
//            //Arrange
//            var testing = new TestDB();
//            var context = testing.CreateContextForInMemory();
//            context.Comments.Add(new Comment
//           {
//                commentID = 1,
//                body = "Comment body",
//                date = "5/224/2022",
//                commentLikes = 30,
//                postID = 1,
//                userID = 1,
                

//             });
//            context.Comments.Add(new Comment
//            {
//                commentID = 2,
//                body = "Comment body",
//                date = "5/224/2022",
//                commentLikes = 300,
//                postID = 2,
//                userID = 2,
                

//             });
  
//            context.SaveChanges();

//            //Act
//            CommentController testController = new CommentController(context);
//            var actionResult = await testController.DeletComments();

//            //Assert
//            List<Comment> comments= actionResult.Value;

//            Assert.Equal(2, comments.Count);
//            var firstComment = comment[0];
//            var secondComment = comment[1];

//            Assert.Equal(1, firstComment.commentID);
//            Assert.Equal("Body", firstComment.body);
//            Assert.Equal("date", firstComment.date);
//            Assert.Equal("Comment likes", firstComment.commentLikes);
//            Assert.Equal("PassWord", firstComment.postID);
//            Assert.Equal("peofilePicture", firstComment.userID);

//            Assert.Equal(2, secondComment.commentID);
//            Assert.Equal("Body", secondComment.body);
//            Assert.Equal("date", secondComment.date);
//            Assert.Equal("Comment likes", secondComment.commentLikes);
//            Assert.Equal("PassWord", secondComment.postID);
//            Assert.Equal("peofilePicture", secondComment.userID);  

          

//        } 
//              [Fact]
//        public async Task CommentController_UpdateComments_GetAllComments()

//        {
//            //Arrange
//            var testing = new TestDB();
//            var context = testing.CreateContextForInMemory();
//            context.Comments.Add(new Comments
//           {
//                commentID = 1,
//                body = "Comment body",
//                date = "5/224/2022",
//                commenyLikes = 30,
//                postID = 1,
//                userID = 1,
                

//             });
//            context.Comments.Add(new Comment
//            {
//                commentID = 2,
//                body = "Comment body",
//                date = "5/224/2022",
//                commentLikes = 300,
//                postID = 2,
//                userID = 2,
                

//             });
  
//            context.SaveChanges();

//            //Act
//            CommentController testController = new CommentController(context);
//            var actionResult = await testController.UpdateComments();

//            //Assert
//            List<Comment> comments= actionResult.Value;

//            Assert.Equal(2, users.Count);
//            var firstComment = comment[0];
//            var secondComment = comment[1];

//            Assert.Equal(1, firstComment.commentID);
//            Assert.Equal("Body", firstComment.body);
//            Assert.Equal("date", firstComment.date);
//            Assert.Equal("Comment likes", firstComment.commentLikes);
//            Assert.Equal("PassWord", firstComment.postID);
//            Assert.Equal("peofilePicture", firstComment.userID);

//            Assert.Equal(2, secondComment.commentID);
//            Assert.Equal("Body", secondComment.body);
//            Assert.Equal("date", secondComment.date);
//            Assert.Equal("Comment likes", secondComment.commentLikes);
//            Assert.Equal("PassWord", secondComment.postID);
//            Assert.Equal("peofilePicture", secondComment.userID);  

          

//        } 
//    }
//}