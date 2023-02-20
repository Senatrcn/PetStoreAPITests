using PetStoreAPITests.Actions.Abstract;
using PetStoreAPITests.Constants;
using PetStoreAPITests.Controller;
using PetStoreAPITests.Models;
using PetStoreAPITests.Models.User;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Web.Http;

namespace PetStoreAPITests.Actions.Concrete
{
    public class UserActions : IUserActions
    {
        private BaseResponse baseUserResponse;
        private RestResponse restResponse;
        private readonly string UserBaseUrl;


        public UserActions()
        {
            UserBaseUrl = BaseConstants.BASE_URL + "user/";
            baseUserResponse = new BaseResponse();
        }

        private T JsonDeserialize<T>(RestResponse restResponse)
        {
            return JsonSerializer.Deserialize<T>(restResponse.Content);
        }

        private T StatusCodeControl<T>(RestResponse restResponse, HttpStatusCode statusCode)
        {
            if (restResponse.StatusCode == statusCode)
            {
                return JsonDeserialize<T>(restResponse);
            }
            else
            {
                throw new HttpResponseException(restResponse.StatusCode);
            }
        }

        public BaseResponse UserLoginAction(string userName, string password)
        {
            ApiControl.SetRequest(Method.Get);
            ApiControl.SetBaseUrl(new Uri(UserBaseUrl + "login" + "?username=" + userName + "&password=" + password));
            restResponse = ApiControl.Execute();

            return StatusCodeControl<BaseResponse>(restResponse, HttpStatusCode.OK);
        }
        public BaseResponse UserLogoutAction()
        {
            ApiControl.SetRequest(Method.Get);
            ApiControl.SetBaseUrl(new Uri(UserBaseUrl + "logout"));
            restResponse = ApiControl.Execute();

            return StatusCodeControl<BaseResponse>(restResponse, HttpStatusCode.OK);
        }

        public BaseResponse CreateUserAction(CreateUserRequest createUserRequest)
        {
            ApiControl.SetRequest(Method.Post);
            ApiControl.SetBaseUrl(new Uri(UserBaseUrl));
            ApiControl.RequestAddJsonBody(JsonSerializer.Serialize(createUserRequest));
            restResponse = ApiControl.Execute();

            return StatusCodeControl<BaseResponse>(restResponse, HttpStatusCode.OK);
        }

        public BaseResponse CreateUserWithListAction(List<CreateUserRequest> createUserRequests)
        {
            ApiControl.SetRequest(Method.Post);
            ApiControl.SetBaseUrl(new Uri(UserBaseUrl + "createWithList"));
            ApiControl.RequestAddJsonBody(JsonSerializer.Serialize(createUserRequests));
            restResponse = ApiControl.Execute();

            return StatusCodeControl<BaseResponse>(restResponse, HttpStatusCode.OK);
        }

        public T GetUserByUserNameAction<T>(string userName, HttpStatusCode httpStatusCode)
        {
            ApiControl.SetRequest(Method.Get);
            ApiControl.SetBaseUrl(new Uri(UserBaseUrl + userName));
            restResponse = ApiControl.Execute();

            return StatusCodeControl<T>(restResponse, httpStatusCode);
        }

        public BaseResponse UpdateUserByUserNameAction(string userName, CreateUserRequest createUserRequest)
        {
            ApiControl.SetRequest(Method.Put);
            ApiControl.SetBaseUrl(new Uri(UserBaseUrl + userName));
            ApiControl.RequestAddJsonBody(JsonSerializer.Serialize(createUserRequest));
            restResponse = ApiControl.Execute();

            return StatusCodeControl<BaseResponse>(restResponse, HttpStatusCode.OK);
        }
        public BaseResponse DeleteUserByUserNameAction(string userName)
        {
            ApiControl.SetRequest(Method.Delete);
            ApiControl.SetBaseUrl(new Uri(UserBaseUrl + userName));
            restResponse = ApiControl.Execute();

            return StatusCodeControl<BaseResponse>(restResponse, HttpStatusCode.OK);
        }
    }
}
