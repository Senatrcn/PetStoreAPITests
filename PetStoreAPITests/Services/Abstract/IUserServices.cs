using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PetStoreAPITests.Services.Abstract
{
    public interface IUserServices
    {
        void UserLoginService(string userName, string password);

        void UserLogoutService();

        void CreateUserService();

        void CreateUserWithListService();

        void GetUserByUserNameService(string userName, HttpStatusCode httpStatusCode);

        void UpdateUserByUserNameService(string userName);

        void DeleteUserByUserNameService(string userName);
    }
}
