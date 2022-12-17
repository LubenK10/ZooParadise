using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooParadise.Infrastructure.Data.Entities;

namespace ZooParadise.Infrastructure.Data.Configuration
{
    public class PetConfiguration : IEntityTypeConfiguration<Pet>
    {
        public void Configure(EntityTypeBuilder<Pet> builder)
        {
            builder.HasData(CreatePets());
        }

        private List<Pet> CreatePets()
        {
            var pets = new List<Pet>();

            var pet = new Pet()
            {
                Id = 1,
                Age = 4,
                ColourId = 4,
                Description = "Sharo was born in Spain",
                Name = "Sharo",
                Price = 650,
                GenderId = 1,
                ImageUrl = "https://media.istockphoto.com/id/1285465107/photo/loyal-golden-retriever-dog-sitting-on-a-green-backyard-lawn-looks-at-camera-top-quality-dog.jpg?b=1&s=170667a&w=0&k=20&c=wlNYMlUWDdPT-N7i4leEjIhYIZo-BSJwDMMWIDnmlto=",
                AnimalTypeId = 1,
                ManagerId = 1
            };


            pets.Add(pet);

            return pets;
        }
    }
}