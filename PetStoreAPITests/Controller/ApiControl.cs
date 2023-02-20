using PetStoreAPITests.Constants;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetStoreAPITests.Controller
{
    public class ApiControl
    {
        internal static RestClient client;
        internal static RestRequest request;

        static ApiControl()
        {
            client = new RestClient(BaseConstants.BASE_URL);
        }

        public static void SetRequest(Method method)
        {
            request = new RestRequest(method.ToString());
        }

        public static RestRequest GetRequest()
        {
            return request;
        }

        public static void RequestAddJsonBody(object obj)
        {
            request.AddJsonBody(obj);
        }

        public static void RequestAddHeader(string headerName, string headerValue)
        {
            request.AddHeader(headerName, headerValue);
        }

        public static void RequestAddFile(string name, string filePath)
        {
            request.AddFile(name, filePath);
        }

        public static void RequestAlwaysMultipartFormData(bool status)
        {
            request.AlwaysMultipartFormData = status;
        }

        public static void SetBaseUrl(Uri uri)
        {
            client = new RestClient(uri);
        }

        public static RestResponse Execute()
        {
            return client.Execute(request);
        }
    }
}
