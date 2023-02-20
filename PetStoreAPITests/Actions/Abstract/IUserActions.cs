using PetStoreAPITests.Models;
using PetStoreAPITests.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PetStoreAPITests.Actions.Abstract
{
    public interface IUserActions
    {
        BaseResponse UserLoginAction(string userName, string password);
        BaseResponse UserLogoutAction();
        BaseResponse CreateUserAction(CreateUserRequest createUserRequest);
        BaseResponse CreateUserWithListAction(List<CreateUserRequest> createUserRequests);
        T GetUserByUserNameAction<T>(string userName, HttpStatusCode httpStatusCode);
        BaseResponse UpdateUserByUserNameAction(string userName, CreateUserRequest createUserRequest);
        BaseResponse DeleteUserByUserNameAction(string userName);
    }
}
