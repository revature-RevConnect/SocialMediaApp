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

        private readonly ILogger<UsersController> _logger;
        [Fact]
        public async Task UsersController_UserPostTest()
        {
            //Arrange
            var testing = new TestDB();
            var context = testing.CreateContextForInMemory();
            var TestUser = new User
            {
                userID = 1,
                authID = "a",
                name = "Testing",
                email = "Teating@test.com",
                profilePicture = " ",
                aboutMe = " ",
                phone = "555-555-5555",
                address = "555 testing st",
                linkedin = "linkedin",
                twitter = "twitter",
                github = "github",
            };



            //Act
            UsersController testController = new UsersController(_logger, context);
            await testController.Post(TestUser);//post
            var result = await testController.Login("a");
            //Assert
            User users = result.Value;
            var firstUser = users;
            Assert.Equal(1, firstUser.userID);
            Assert.Equal("a", firstUser.authID);
            Assert.Equal("Testing", firstUser.name);
            Assert.Equal(" ", firstUser.profilePicture);
            Assert.Equal("555-555-5555", firstUser.phone);
            Assert.Equal(" ", firstUser.aboutMe);
            Assert.Equal("linkedin", firstUser.linkedin);
            Assert.Equal("twitter", firstUser.twitter);
            Assert.Equal("github", firstUser.github);

        }
        //////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////
        [Fact]
        public async Task UserController_UserLoginTest()
        {
            //Arrange
            var testing = new TestDB();
            var context = testing.CreateContextForInMemory();
            context.Users.Add(new User
            {
                userID = 1,
                authID = "a",
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
            UsersController testController = new UsersController(_logger, context);
            var actionResult = await testController.Login("a");

            //Assert
            User users = actionResult.Value;
            var firstUser = users;

            Assert.Equal(1, firstUser.userID);
            Assert.Equal("a", firstUser.authID);
            Assert.Equal("Testing", firstUser.name);
            Assert.Equal(" ", firstUser.profilePicture);
            Assert.Equal("555-555-5555", firstUser.phone);
            Assert.Equal(" ", firstUser.aboutMe);
            Assert.Equal("linkedin", firstUser.linkedin);
            Assert.Equal("twitter", firstUser.twitter);
            Assert.Equal("github", firstUser.github);
        }
        //////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////
        [Fact]
        public async Task UserController_ChangeUserNameTest()
        {
            //Arrange
            var testing = new TestDB();
            var context = testing.CreateContextForInMemory();
            context.Users.Add(new User
            {
                userID = 1,
                authID = "a",
                name = "Testing",
                email = "Testing@test.com",
                profilePicture = " ",
                aboutMe = " ",
                phone = "555-555-5555",
                address = "555 testing st",
                linkedin = "linkedin",
                twitter = "twitter",
                github = "github",
            });

            context.SaveChanges();
            var newUser = new User { authID = "a", name = "ChangedTest" };

            //Act
            UsersController testController = new UsersController(_logger, context);
            var actionResult = await testController.ChangeUserName(newUser);
            var getresult = await testController.Login("a");
            //Assert
            User users = getresult.Value;
            var firstUser = users;
            Assert.Equal("a", firstUser.authID);
            Assert.Equal("ChangedTest", firstUser.name);
            Assert.Equal("Testing@test.com", firstUser.email);

        }
        //////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////
        [Fact]
        public async Task UserController_ChangePictureTest()
        {
            //Arrange
            var testing = new TestDB();
            var context = testing.CreateContextForInMemory();
            context.Users.Add(new User
            {
                userID = 1,
                authID = "a",
                name = "Testing",
                email = "Testing@test.com",
                profilePicture = " ",
                aboutMe = " ",
                phone = "555-555-5555",
                address = "555 testing st",
                linkedin = "linkedin",
                twitter = "twitter",
                github = "github",
            });

            context.SaveChanges();
            var newUser = new User { authID = "a", profilePicture = "ChangedTest" };

            //Act
            UsersController testController = new UsersController(_logger, context);
            var actionResult = await testController.ChangePicture(newUser);
            var getresult = await testController.Login("a");
            //Assert
            User users = getresult.Value;
            var firstUser = users;
            Assert.Equal("a", firstUser.authID);
            Assert.Equal("ChangedTest", firstUser.profilePicture);
            Assert.Equal("Testing@test.com", firstUser.email);
        }
        //////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////
        [Fact]
        public async Task UserController_ChangeAboutTest()
        {
            //Arrange
            var testing = new TestDB();
            var context = testing.CreateContextForInMemory();
            context.Users.Add(new User
            {
                userID = 1,
                authID = "a",
                name = "Testing",
                email = "Testing@test.com",
                profilePicture = " ",
                aboutMe = " ",
                phone = "555-555-5555",
                address = "555 testing st",
                linkedin = "linkedin",
                twitter = "twitter",
                github = "github",
            });

            context.SaveChanges();
            var newUser = new User { authID = "a", aboutMe = "ChangedTest" };

            //Act
            UsersController testController = new UsersController(_logger, context);
            await testController.ChangeAboutMe(newUser);
            var getresult = await testController.Login("a");
            //Assert
            var result = getresult.Value;

            Assert.Equal("a", result.authID);
            Assert.Equal("ChangedTest", result.aboutMe);
            Assert.Equal("Testing@test.com", result.email);


        }
        //////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////
        [Fact]
        public async Task UserController_ChangePhoneTest()
        {
            //Arrange
            var testing = new TestDB();
            var context = testing.CreateContextForInMemory();
            context.Users.Add(new User
            {
                userID = 1,
                authID = "a",
                name = "Testing",
                email = "Testing@test.com",
                profilePicture = " ",
                aboutMe = " ",
                phone = "555-555-5555",
                address = "555 testing st",
                linkedin = "linkedin",
                twitter = "twitter",
                github = "github",
            });

            context.SaveChanges();
            var newUser = new User { authID = "a", phone = "ChangedTest" };

            //Act
            UsersController testController = new UsersController(_logger, context);
            var actionResult = await testController.ChangePhoneNumber(newUser);
            var getresult = await testController.Login("a");
            //Assert
            User users = getresult.Value;
            var firstUser = users;
            Assert.Equal("a", firstUser.authID);
            Assert.Equal("ChangedTest", firstUser.phone);
            Assert.Equal("Testing@test.com", firstUser.email);
        }
        /////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////
        [Fact]
        public async Task UserController_ChangeEmailTest()
        {
            //Arrange
            var testing = new TestDB();
            var context = testing.CreateContextForInMemory();
            context.Users.Add(new User
            {
                userID = 1,
                authID = "a",
                name = "Testing",
                email = "Testing@test.com",
                profilePicture = " ",
                aboutMe = " ",
                phone = "555-555-5555",
                address = "555 testing st",
                linkedin = "linkedin",
                twitter = "twitter",
                github = "github",
            });

            context.SaveChanges();
            var newUser = new User { authID = "a", email = "ChangedTest" };

            //Act
            UsersController testController = new UsersController(_logger, context);
            var actionResult = await testController.ChangeEmail(newUser);
            var getresult = await testController.Login("a");
            //Assert
            User users = getresult.Value;
            var firstUser = users;
            Assert.Equal("a", firstUser.authID);
            Assert.Equal("Testing", firstUser.name);
            Assert.Equal("ChangedTest", firstUser.email);
        }

        /////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////
        [Fact]
        public async Task UserController_ChangeAddressTest()
        {
            //Arrange
            var testing = new TestDB();
            var context = testing.CreateContextForInMemory();
            context.Users.Add(new User
            {
                userID = 1,
                authID = "a",
                name = "Testing",
                email = "Testing@test.com",
                profilePicture = " ",
                aboutMe = " ",
                phone = "555-555-5555",
                address = "555 testing st",
                linkedin = "linkedin",
                twitter = "twitter",
                github = "github",
            });

            context.SaveChanges();
            var newUser = new User { authID = "a", address = "ChangedTest" };

            //Act
            UsersController testController = new UsersController(_logger, context);
            var actionResult = await testController.ChangeAddress(newUser);
            var getresult = await testController.Login("a");
            //Assert
            User users = getresult.Value;
            var firstUser = users;
            Assert.Equal("a", firstUser.authID);
            Assert.Equal("Testing", firstUser.name);
            Assert.Equal("ChangedTest", firstUser.address);
        }
        /////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////
        [Fact]
        public async Task UserController_ChangeGithubTest()
        {
            //Arrange
            var testing = new TestDB();
            var context = testing.CreateContextForInMemory();
            context.Users.Add(new User
            {
                userID = 1,
                authID = "a",
                name = "Testing",
                email = "Testing@test.com",
                profilePicture = " ",
                aboutMe = " ",
                phone = "555-555-5555",
                address = "555 testing st",
                linkedin = "linkedin",
                twitter = "twitter",
                github = "github",
            });

            context.SaveChanges();
            var newUser = new User { authID = "a", github = "ChangedTest" };

            //Act
            UsersController testController = new UsersController(_logger, context);
            var actionResult = await testController.ChangeGithub(newUser);
            var getresult = await testController.Login("a");
            //Assert
            User users = getresult.Value;
            var firstUser = users;
            Assert.Equal("a", firstUser.authID);
            Assert.Equal("Testing", firstUser.name);
            Assert.Equal("ChangedTest", firstUser.github);
        }

        /////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////
        [Fact]
        public async Task UserController_ChangeTwitterTest()
        {
            //Arrange
            var testing = new TestDB();
            var context = testing.CreateContextForInMemory();
            context.Users.Add(new User
            {
                userID = 1,
                authID = "a",
                name = "Testing",
                email = "Testing@test.com",
                profilePicture = " ",
                aboutMe = " ",
                phone = "555-555-5555",
                address = "555 testing st",
                linkedin = "linkedin",
                twitter = "twitter",
                github = "github",
            });

            context.SaveChanges();
            var newUser = new User { authID = "a", twitter = "ChangedTest" };

            //Act
            UsersController testController = new UsersController(_logger, context);
            var actionResult = await testController.ChangeTwitter(newUser);
            var getresult = await testController.Login("a");
            //Assert
            User users = getresult.Value;
            var firstUser = users;
            Assert.Equal("a", firstUser.authID);
            Assert.Equal("Testing", firstUser.name);
            Assert.Equal("ChangedTest", firstUser.twitter);
        }
        /////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////
        [Fact]
        public async Task UserController_ChangeLinkedInTest()
        {
            //Arrange
            var testing = new TestDB();
            var context = testing.CreateContextForInMemory();
            context.Users.Add(new User
            {
                userID = 1,
                authID = "a",
                name = "Testing",
                email = "Testing@test.com",
                profilePicture = " ",
                aboutMe = " ",
                phone = "555-555-5555",
                address = "555 testing st",
                linkedin = "linkedin",
                twitter = "twitter",
                github = "github",
            });

            context.SaveChanges();
            var newUser = new User { authID = "a", linkedin = "ChangedTest" };

            //Act
            UsersController testController = new UsersController(_logger, context);
            var actionResult = await testController.ChangeLinkedIn(newUser);
            var getresult = await testController.Login("a");
            //Assert
            User users = getresult.Value;
            var firstUser = users;
            Assert.Equal("a", firstUser.authID);
            Assert.Equal("Testing", firstUser.name);
            Assert.Equal("ChangedTest", firstUser.linkedin);
        }
    }
}