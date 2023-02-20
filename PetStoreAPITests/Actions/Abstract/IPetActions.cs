using PetStoreAPITests.Models;
using PetStoreAPITests.Models.Pet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetStoreAPITests.Actions.Abstract
{
    public interface IPetActions
    {
        CreatePetResponse CreatePetAction(CreatePetRequest createPetRequest);
        BaseResponse UploadPetImageAction(long id);
        BaseResponse GetPetWithIdAction(long id);
    }
}
