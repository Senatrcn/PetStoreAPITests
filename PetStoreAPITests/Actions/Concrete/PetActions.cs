using PetStoreAPITests.Actions.Abstract;
using PetStoreAPITests.Constants;
using PetStoreAPITests.Controller;
using PetStoreAPITests.Models;
using PetStoreAPITests.Models.Pet;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Web.Http;
using ApiControl = PetStoreAPITests.Controller.ApiControl;

namespace PetStoreAPITests.Actions.Concrete
{
    public class PetActions : IPetActions
    {
        private BaseResponse baseResponse;
        private CreatePetResponse createPetResponse;
        private RestResponse restResponse;
        private readonly string PetBaseUrl;


        public PetActions()
        {
            PetBaseUrl = BaseConstants.BASE_URL + "pet/";
            baseResponse = new BaseResponse();
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

        public CreatePetResponse CreatePetAction(CreatePetRequest createPetRequest)
        {
            ApiControl.SetRequest(Method.Post);
            ApiControl.SetBaseUrl(new Uri(PetBaseUrl));
            ApiControl.RequestAddJsonBody(JsonSerializer.Serialize(createPetRequest));
            restResponse = ApiControl.Execute();

            return StatusCodeControl<CreatePetResponse>(restResponse, HttpStatusCode.OK);
        }

        public BaseResponse GetPetWithIdAction(long id)
        {
            ApiControl.SetRequest(Method.Get);
            ApiControl.SetBaseUrl(new Uri(PetBaseUrl + id));
            restResponse = ApiControl.Execute();

            return StatusCodeControl<BaseResponse>(restResponse, HttpStatusCode.NotFound);
        }

        public BaseResponse UploadPetImageAction(long id)
        {
            ApiControl.SetRequest(Method.Post);
            ApiControl.SetBaseUrl(new Uri(PetBaseUrl + id + "/uploadImage"));
            ApiControl.RequestAddHeader("Content-Type", "multipart/form-data");
            ApiControl.RequestAlwaysMultipartFormData(true);
            ApiControl.RequestAddFile("file", Directory.GetCurrentDirectory() + "/Image/dog.jpg");
            restResponse = ApiControl.Execute();

            return StatusCodeControl<BaseResponse>(restResponse, HttpStatusCode.OK);

        }
    }
}
