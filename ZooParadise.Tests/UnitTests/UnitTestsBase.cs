using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooParadise.Infrastructure.Data;
using ZooParadise.Infrastructure.Data.Entities;
using ZooParadise.Tests.Mock;

namespace ZooParadise.Tests.UnitTests
{
    public class UnitTestsBase
    {
        protected ApplicationDbContext data;

        [OneTimeSetUp]
        public void SetUpBase()
        {
            this.data = DatabaseMock.Instance;
            this.SeedDatabase();
        }

        public User Adopter { get; set; } = null!;

        public Manager Manager { get; set; } = null!;

        public Pet AdoptedPet { get; set; } = null!;


        private void SeedDatabase()
        {
              this.Adopter = new User()
            {
                Id = "RenterId",
                UserName = "manager@gmail.com",
                NormalizedUserName = "manager@gmail.com",
                Email = "manager@gmail.com",
                NormalizedEmail = "manager@gmail.com"
            };

            this.data.Users.Add(this.Adopter);

              this.Manager = new Manager()
             {
                 Id = 1,
                 Phone = "+359 89 887 6756",
                 UserId = "UserId"
             };
        
              this.data.Managers.Add(this.Manager);

            this.AdoptedPet = new Pet()
            {
                Id = 1,
                Age = 4,
                Colour = new Colour() {Name = "Black"},
                Description = "Description one",
                Name = "Sharo",
                Price = 650,
                Gender = new Gender() {Name = "Male"},
                ImageUrl = "https://shorebread.com/wp-content/uploads/2018/11/adorable-animal-black-dog-1133082.jpg",
                AnimalType = new AnimalType() {Name = "Dog"},
                Manager = this.Manager,
                Adopter = this.Adopter
            };

            this.data.Pets.Add(AdoptedPet);

            var NotAdoptpedPet = new Pet()
            {
                Id = 2,
                Age = 3,
                Colour = new Colour() { Name = "White" },
                Description = "Description two",
                Name = "Maya",
                Price = 700,
                Gender = new Gender() { Name = "Male" },
                ImageUrl = "https://blog.ferplast.com/wp-content/uploads/2019/07/owning-a-white-cat-5b1b91a318ba9-1024x683.jpg",
                AnimalType = new AnimalType() { Name = "Cat" },
                Manager = this.Manager,
                Adopter = this.Adopter
            };

            this.data.Pets.Add(NotAdoptpedPet);
            this.data.SaveChanges();
        }

        [OneTimeTearDown]
        public void TearDownBase() => data.Dispose();
    }
}
