using NUnit.Framework;
using PetStoreAPITests.Services.Abstract;
using PetStoreAPITests.Services.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetStoreAPITests.Tests
{
    public class PetTests
    {
        public IPetServices petServices;

        public PetTests()
        {
            petServices = new PetServices();
        }

        [Test]
        public void CreatePet()
        {
            petServices.CreatePetService();
        }

        [Test]
        [TestCase(1001)]
        public void GetPetWithPetId(long id)
        {
            petServices.GetPetWithPetIdService(id);
        }

        [Test]
        [TestCase(1001)]
        public void UploadPetImage(long id)
        {
            petServices.UploadPetImageService(id);
        }
    }
}
