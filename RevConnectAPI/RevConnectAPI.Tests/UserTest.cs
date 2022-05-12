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
    public class UserTest
    {
        //Diego Wrote the Get Test for User Controller
        /*NOT DONE Add post test...*/
        [Fact]
        public async Task UserController_GetUsers_GetAllUsers()
        {
            //Arrange
            var testing = new TestDB();
            var context = testing.CreateContextForInMemory();
            context.Users.Add(new User
            {
                userID = 1,
                firstName = "FirstName",
                lastName = "LastName",
                userName = "UserName",
                password = "password",
                profilePicture = "profilepic"
            });
            context.Users.Add(new User
            {
                userID = 2,
                firstName = "FirstName2",
                lastName = "LastName2",
                userName = "UserName2",
                password = "password2",
                profilePicture = "profilepic2"
            });
            context.SaveChanges();
            //Act
            UserController testController = new UserController(context);
            var users = await testController.GetUsers();//This is where the GetUsers method from the controller is called
            var users1 = users.Value;

            //Assert
            Assert.Equal(1, users1[0].userID);
            Assert.Equal("FirstName", users1[0].firstName);
            Assert.Equal(2, users1[1].userID);
            Assert.Equal("FirstName2", users1[1].firstName);
            Assert.Equal(2, users1.Count);


        }
    }
}
