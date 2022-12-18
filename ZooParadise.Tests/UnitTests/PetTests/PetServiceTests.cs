using Microsoft.AspNetCore.Identity;
using NUnit.Framework;
using System.Linq;
using ZooParadise.Core.Contracts;
using ZooParadise.Core.Contracts.Admin;
using ZooParadise.Core.Services;
using ZooParadise.Core.Services.Admin;
using ZooParadise.Infrastructure.Data.Entities;

namespace ZooParadise.Tests.UnitTests.PetTests
{
    public class PetServiceTests : UnitTestsBase
    {
        private IPetService petService;
        private IUserService userService;
        private UserManager<User> userManager;

        [OneTimeSetUp]
        public void SetUp()
        {
            petService = new PetService(this.data);
            userService = new UserService(this.data, userManager);
        }

        [Test]
        public void AllAnimalTypes()
        {
            var result = petService.AllAnimalTypes();

            var types = data.AnimalTypes;

            Assert.That(result.Result.Count, Is.EqualTo(types.Count()));

            var typesNames = types.Select(p => p.Name);
            Assert.That(typesNames.Contains(result.Result.First().Name));
        }

        [Test]
        public void AllColours()
        {
            var result = petService.AllColours();

            var colours = data.Colours;

            Assert.That(result.Result.Count, Is.EqualTo(colours.Count()));

            var coloursNames = colours.Select(p => p.Name);

            Assert.That(coloursNames.Contains(result.Result.First().Name));
        }

        [Test]
        public void AllGenders()
        {
            var result = petService.AllGenders();

            var genders = data.Genders;

            Assert.That(result.Result.Count, Is.EqualTo(genders.Count()));

            var gendersNames = genders.Select(p => p.Name);

            Assert.That(gendersNames.Contains(result.Result.First().Name));
        }

        [Test]
        public void All_ShouldReturnCorrectPets()
        {
            var searchTerm = "sha";

            var result = this.petService.All(null, null, null, searchTerm);

            var petInDb = this.data.Pets
            .Where(x => x.Name.ToLower().Contains(searchTerm.ToLower()) ||
                        x.AnimalType.Name.ToLower().Contains(searchTerm.ToLower()));

            Assert.AreEqual(result.Result.PetsCount, petInDb.Count());

            var resultcar = result.Result.Pets.FirstOrDefault();
            Assert.IsNotNull(result);

            var carrInDb = petInDb.FirstOrDefault();
        
             Assert.That(resultcar.Name, Is.EqualTo(carrInDb.Name));
             Assert.That(resultcar.Id, Is.EqualTo(carrInDb.Id));
            

        }
        [Test]
        public void AllAnimalTypesNames()
        {
            var result = petService.AllAnimalTypesNames();

            var types = data.AnimalTypes;


            var typesNames = types.Select(p => p.Name);
            Assert.That(typesNames.Contains(result.Result.First()));
        }

        [Test]
        public void AllColoursNames()
        {
            var result = petService.AllColoursNames();

            var colours = data.Colours;


            var coloursNames = colours.Select(p => p.Name);

            Assert.That(coloursNames.Contains(result.Result.First()));
        }

        [Test]
        public void AllGendersNames()
        {
            var result = petService.AllGendersNames();

            var genders = data.Genders.Distinct();


            var gendersNames = genders.Select(p => p.Name);

            Assert.That(gendersNames.Contains(result.Result.First()));
        }

        [Test]
        public void AllPetsByManagerId()
        {
            var managerId = this.Manager.Id;

            var result = petService.AllPetsByManagerId(managerId);

            Assert.IsNotNull(result.Result);

            var pets = data.Pets.Where(m => m.ManagerId == managerId);

            Assert.That(result.Result.Count, Is.EqualTo(pets.Count()));
        }

        [Test]
        public void AllPetsByUserId()
        {
            var adopterId = this.Adopter.Id;

            var result = petService.AllPetsByUserId(adopterId);

            Assert.IsNotNull(result.Result);

            var pets = data.Pets.Where(m => m.AdopterId == adopterId);

            Assert.That(result.Result.Count, Is.EqualTo(pets.Count()));
        }

         

        [Test]
        public void Test_IsAdopted_ShouldBeTrue()
        {
            var result = petService.IsAdopted(AdoptedPet.Id);
            Assert.IsTrue(result.Result);
        }


        [Test]
        public void Test_LastThreePets()
        {
            var result = petService.LastThreePets();

            var petInDB = this.data.Pets
            .OrderByDescending(h => h.Id)
            .Take(3);

            Assert.That(result.Result.Count(), Is.EqualTo(petInDB.Count()));

            var firstCarInDb = petInDB
            .FirstOrDefault();

            var firstResultCar = result.Result.FirstOrDefault();
            Assert.That(firstResultCar.Name, Is.EqualTo(firstCarInDb.Name));
        }


        [Test]
        public void Adopt_ShouldWork()
        {
            Pet pet = new Pet()
            {
                Id = 3,
                Age = 5,
                Colour = new Colour() { Name = "Black" },
                Description = "Description one",
                Name = "Sharo",
                Price = 650,
                Gender = new Gender() { Name = "Male" },
                ImageUrl = "https://shorebread.com/wp-content/uploads/2018/11/adorable-animal-black-dog-1133082.jpg",
                AnimalType = new AnimalType() { Name = "Dog" }
            };

            data.Pets.Add(pet);
            data.SaveChanges();

            petService.Adopt(pet.Id, Adopter.Id);
            var newCarInDb = data.Pets.Find(pet.Id);

            Assert.IsNotNull(newCarInDb);
            Assert.AreEqual(pet.AdopterId, Adopter.Id);
        }

        [Test]
        public void Leave_ShouldWork()
        {
            Pet pet = new Pet()
            {
                Id = 4,
                Age = 5,
                Colour = new Colour() { Name = "Black" },
                Description = "Description one",
                Name = "Sharo",
                Price = 650,
                Gender = new Gender() { Name = "Male" },
                ImageUrl = "https://shorebread.com/wp-content/uploads/2018/11/adorable-animal-black-dog-1133082.jpg",
                AnimalType = new AnimalType() { Name = "Dog" }
            };

            data.Pets.Add(pet);
            data.SaveChanges();

            petService.Adopt(pet.Id, Adopter.Id);
            Assert.IsNotNull(pet.AdopterId);

            petService.Leave(pet.Id);
            Assert.IsNull(pet.AdopterId);
        }

        [Test]
        public void Delete_ShouldWork()
        {
            Pet pet = new Pet()
            {
                Id = 5,
                Age = 5,
                Colour = new Colour() { Name = "Black" },
                Description = "Description one",
                Name = "Sharo",
                Price = 650,
                Gender = new Gender() { Name = "Male" },
                ImageUrl = "https://shorebread.com/wp-content/uploads/2018/11/adorable-animal-black-dog-1133082.jpg",
                AnimalType = new AnimalType() { Name = "Dog" }
            };

            data.Pets.Add(pet);
            data.SaveChanges();
            Assert.IsNotNull(data.Pets.Find(pet.Id));

            petService.Delete(pet.Id);

            Assert.IsFalse(pet.IsAvailable);
        }

        [Test]
        public void GetAnimalTypeId()
        {
            int petId = AdoptedPet.Id;
            var result = petService.GetAnimalTypeId(petId);
            Assert.IsNotNull(result.Result);

            int id = AdoptedPet.AnimalType.Id;
            Assert.AreEqual(id, result.Result);
        }

        [Test]
        public void GetGenderId()
        {
            int petId = AdoptedPet.Id;
            var result = petService.GetGenderId(petId);
            Assert.IsNotNull(result.Result);

            int id = AdoptedPet.Gender.Id;
            Assert.AreEqual(id, result.Result);
        }

        [Test]
        public void GetColourId()
        {
            int petId = AdoptedPet.Id;
            var result = petService.GetColourId(petId);
            Assert.IsNotNull(result.Result);

            int id = AdoptedPet.Colour.Id;
            Assert.AreEqual(id, result.Result);
        }

        [Test]

        public void HasManagerWithId_ShouldReturnTrue_WithValidId()
        {
            var id = this.AdoptedPet.Id;
            var userId = this.AdoptedPet.Manager.UserId;
            var result = this.petService.HasManagerWithId(id, userId);

            Assert.IsTrue(result.Result);
        }

        [Test]
        public void Exists_ShouldReturnTrue_WithValidId()
        {
            var id = this.AdoptedPet.Id;
            var result = this.petService.Exists(id);

            Assert.IsTrue(result.Result);
        }

        [Test]
        public void Test_IsAdoptedByUserWithId_ShouldBeTrue()
        {
            var id = AdoptedPet.Id;
            var ownerId = "RenterId";
            var adopt = petService.IsAdoptedByUser(id, ownerId);
            Assert.IsTrue(adopt.Result);
        }

        [Test]
        public void AllPetsByManagerId_ShouldWork_WithValidId()
        {
            var id = Manager.Id;
            var result = petService.AllPetsByManagerId(id);
            Assert.IsNotNull(result);

            var petInDb = data.Pets.Where(x => x.ManagerId == id);

            Assert.AreEqual(petInDb.Count(), result.Result.Count());
        }

    }
}
