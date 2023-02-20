using NUnit.Framework;
using PetStoreAPITests.Services.Abstract;
using PetStoreAPITests.Services.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PetStoreAPITests.Tests
{
    public class UserTests
    {
        public IUserServices userServices;

        public UserTests()
        {
            userServices = new UserServices();
        }
        [Test]
        [TestCase("TestUser","TestPassword")]
        public void UserLogin(string userName, string password)
        {
            userServices.UserLoginService(userName, password);
        }

        [Test]
        public void UserLogout()
        {
            userServices.UserLogoutService();
        }

        [Test]
        public void CreateUser()
        {
            userServices.CreateUserService();
        }

        [Test]
        public void CreateUserWithList()
        {
            userServices.CreateUserWithListService();
        }

        [Test]
        [TestCase("TestUser",HttpStatusCode.OK)]
        public void GetUserByUserName(string userName, HttpStatusCode httpStatusCode)
        {
            userServices.GetUserByUserNameService(userName, httpStatusCode);
        }

        [Test]
        [TestCase("TestUser")]
        public void UpdateUserByUserName(string userName)
        {
            userServices.UpdateUserByUserNameService(userName);
        }

        [Test]
        [TestCase("TestUser")]
        public void DeleteUserByUserName(string userName)
        {
            userServices.DeleteUserByUserNameService(userName);
        }
    }
}
