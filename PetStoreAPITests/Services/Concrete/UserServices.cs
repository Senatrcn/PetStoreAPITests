using NUnit.Framework;
using PetStoreAPITests.Actions.Abstract;
using PetStoreAPITests.Actions.Concrete;
using PetStoreAPITests.Constants;
using PetStoreAPITests.Models;
using PetStoreAPITests.Models.User;
using PetStoreAPITests.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PetStoreAPITests.Services.Concrete
{
    public class UserServices : IUserServices
    {
        private IUserActions userActions;
        private BaseResponse baseResponse;
        private GetUserResponse getUserResponse;

        public UserServices()
        {
            userActions = new UserActions();
        }

        public void UserLoginService(string userName, string password)
        {
            baseResponse = userActions.UserLoginAction(userName, password);

            if (baseResponse.Code == 200)
            {
                Asserts.assertTrue(baseResponse.Message.Contains("logged in user session:"));
            }
            else
            {
                Asserts.Fail("Status Code : " + baseResponse.Code + "\nMessage : " + baseResponse.Message);
            }
        }

        public void UserLogoutService()
        {
            baseResponse = userActions.UserLogoutAction();

            if (baseResponse.Code == 200)
            {
                Asserts.Equals("ok", baseResponse.Message);
            }
            else
            {
                Asserts.Fail("Status Code : " + baseResponse.Code + "\nMessage : " + baseResponse.Message);
            }
        }

        public void CreateUserService()
        {
            baseResponse = userActions.CreateUserAction(new CreateUserRequest
            {
                Id = 0,
                FirstName = "McDirect",
                LastName = "Api",
                Email = "McDirectApi@md.com",
                UserName = "McDirectApi",
                Password = "12345",
                Phone = "05555555555",
                UserStatus = 0
            });

            if (baseResponse.Code == 200)
            {
                Asserts.IsNotEmpty(baseResponse.Message);
            }
            else
            {
                Asserts.Fail("Status Code : " + baseResponse.Code + "\nMessage : " + baseResponse.Message);
            }
        }

        public void CreateUserWithListService()
        {
            List<CreateUserRequest> createUserRequests = new List<CreateUserRequest>();
            createUserRequests.Add(
                new CreateUserRequest
                {
                    Id = 0,
                    FirstName = "Test",
                    LastName = "Test",
                    Email = "McDirectApi@md.com",
                    UserName = "testusername",
                    Password = "324234",
                    Phone = "05325555555",
                    UserStatus = 0
                }
            );
            createUserRequests.Add(
                new CreateUserRequest
                {
                    Id = 0,
                    FirstName = "Mert",
                    LastName = "Namert",
                    Email = "McDirectApi@md.com",
                    UserName = "MertNamert",
                    Password = "324234",
                    Phone = "05325555555",
                    UserStatus = 0
                }
            );

            baseResponse = userActions.CreateUserWithListAction(createUserRequests);

            if (baseResponse.Code == 200)
            {
                Asserts.IsNotEmpty(baseResponse.Message);
            }
            else
            {
                Asserts.Fail("Status Code : " + baseResponse.Code + "\nMessage : " + baseResponse.Message);
            }
        }

        public void GetUserByUserNameService(string userName, HttpStatusCode httpStatusCode)
        {
            if (httpStatusCode == HttpStatusCode.OK)
            {
                getUserResponse = userActions.GetUserByUserNameAction<GetUserResponse>(userName, httpStatusCode);
                Asserts.assertTrue(getUserResponse.Id > 0);
                Asserts.IsNotEmpty(getUserResponse.UserName);
                Asserts.IsNotEmpty(getUserResponse.Password);
                Asserts.IsNotEmpty(getUserResponse.Email);
            }
            else if (httpStatusCode == HttpStatusCode.NotFound)
            {
                baseResponse = userActions.GetUserByUserNameAction<BaseResponse>(userName, httpStatusCode);
                Asserts.Equals("User not found", baseResponse.Message);
                Asserts.Equals(1, baseResponse.Code);
                Asserts.Equals("error", baseResponse.Type);
            }
            else
            {
                Asserts.Fail(UserMessageConstants.USER_NOT_GET);
            }
        }

        public void UpdateUserByUserNameService(string userName)
        {
            baseResponse = userActions.UpdateUserByUserNameAction(userName, new CreateUserRequest
            {
                Id = 0,
                FirstName = "McDirect",
                LastName = "Updated",
                Email = "McDirectApi@md.com",
                UserName = "McDirectApi",
                Password = "12345",
                Phone = "05555555555",
                UserStatus = 0
            });

            if (baseResponse.Code == 200)
            {
                Asserts.IsNotEmpty(baseResponse.Message);
            }
            else
            {
                Asserts.Fail("Status Code : " + baseResponse.Code + "\nMessage : " + baseResponse.Message);
            }
        }
        public void DeleteUserByUserNameService(string userName)
        {
            baseResponse = userActions.UpdateUserByUserNameAction(userName, new CreateUserRequest
            {
                Id = 0,
                FirstName = "McDirect",
                LastName = "Updated",
                Email = "McDirectApi@md.com",
                UserName = "McDirectApi",
                Password = "12345",
                Phone = "05555555555",
                UserStatus = 0
            });

            if (baseResponse.Code == 200)
            {
                Asserts.IsNotEmpty(baseResponse.Message);
            }
            else
            {
                Asserts.Fail("Status Code : " + baseResponse.Code + "\nMessage : " + baseResponse.Message);
            }
        }

    }
}
