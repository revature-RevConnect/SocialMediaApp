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
    public class UsersTest
    {

        private readonly ILogger<UsersController> _logger ;
        [Fact]
        public async Task UsersController_UserPostTest()
        {
            //Arrange
            var testing = new TestDB();
            var context = testing.CreateContextForInMemory();
            context.Users.Add(new User
            {
                userID = 1,
                authID = "",
                name = "Testing",
                email = "Teating@test.com",
                profilePicture =  " ",
                aboutMe = " ",
                phone = "555-555-5555",
                address = "555 testing st",
                linkedin = "linkedin",
                twitter = "twitter",
                github = "github",
            });
            context.SaveChanges();
            //Act
            UsersController testController = new UsersController(_logger,context);
            var actionResult = await testController.Post();//post
            //Assert
            List<User> users = actionResult.Value;
            var firstUser = users[0];
            Assert.Equal(1, firstUser.userID);
            Assert.Equal("", firstUser.authID);
            Assert.Equal("Testing", firstUser.name);
            Assert.Equal(" ", firstUser.profilePicture);
            Assert.Equal("555-555-5555", firstUser.phone);
            Assert.Equal(" ", firstUser.aboutMe);
            Assert.Equal("linkedin", firstUser.linkedin);
            Assert.Equal("twitter", firstUser.twitter);
            Assert.Equal("github", firstUser.github);
            
        }

        [Fact]
        public async Task UserController_UserLoginTest()

        {
            //Arrange
            var testing = new TestDB();
            var context = testing.CreateContextForInMemory();
            context.Users.Add(new User
            {
                userID = 1,
                authID = "",
                name = "Testing",
                email = "Teating@test.com",
                profilePicture = " ",
                aboutMe = " ",
                phone = "555-555-5555",
                address = "555 testing st",
                linkedin = "linkedin",
                twitter = "twitter",
                github = "github",
            });
            
            context.SaveChanges();

            //Act
            UsersController testController = new UsersController(_logger,context);
            var actionResult = await testController.Login();

            //Assert
            List<User> users = actionResult.Value;

            Assert.Equal(1, users.Count);
            var firstUser = users[0];

            Assert.Equal(1, firstUser.userID);
            Assert.Equal("", firstUser.authID);
            Assert.Equal("Testing", firstUser.name);
            Assert.Equal(" ", firstUser.profilePicture);
            Assert.Equal("555-555-5555", firstUser.phone);
            Assert.Equal(" ", firstUser.aboutMe);
            Assert.Equal("linkedin", firstUser.linkedin);
            Assert.Equal("twitter", firstUser.twitter);
            Assert.Equal("github", firstUser.github);
        }

    }
}