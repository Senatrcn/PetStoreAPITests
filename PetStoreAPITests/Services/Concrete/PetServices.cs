using NUnit.Framework;
using PetStoreAPITests.Actions.Abstract;
using PetStoreAPITests.Actions.Concrete;
using PetStoreAPITests.Constants;
using PetStoreAPITests.Models;
using PetStoreAPITests.Models.Pet;
using PetStoreAPITests.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetStoreAPITests.Services.Concrete
{
    public class PetServices : IPetServices
    {
        private IPetActions petActions;
        private BaseResponse baseResponse;
        private CreatePetResponse createPetResponse;

        public PetServices()
        {
            petActions = new PetActions();
        }

        public void CreatePetService()
        {
            List<Tag> tags = new List<Tag>();
            tags.Add(
                new Tag
                {
                    Id = 0,
                    Name = "TAG"
                });
            createPetResponse = petActions.CreatePetAction(new CreatePetRequest
            {
                Id = 0,
                Category = new Category
                {
                    Id = 0,
                    Name = "Dogs"
                },
                Name = "ScoobyDoo",
                PhotoUrls = new[] { "Url-1", "Url-2" },
                Tags = tags,
                Status = "Available"
            });
            Asserts.assertTrue(createPetResponse.Id > 0);
        }

        public void GetPetWithPetIdService(long id)
        {
            baseResponse = petActions.GetPetWithIdAction(id);
            Asserts.Equals("Pet not found", baseResponse.Message);
            Asserts.Equals("error", baseResponse.Type);
        }

        public void UploadPetImageService(long id)
        {
            baseResponse = petActions.UploadPetImageAction(id);

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
