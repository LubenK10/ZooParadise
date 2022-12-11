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
    public class AnimalTypesConfiguration : IEntityTypeConfiguration<AnimalType>
    {
        public void Configure(EntityTypeBuilder<AnimalType> builder)
        {
            builder.HasData(CreateAnimalTypes());
        }

        private List<AnimalType> CreateAnimalTypes()
        {
            var types = new List<AnimalType>();

            var type = new AnimalType
            {
                Id = 1,
                Name = "Dog"
            };

            types.Add(type);

            type = new AnimalType
            {
                Id = 2,
                Name = "Cat"
            };

            types.Add(type);

            type = new AnimalType
            {
                Id = 3,
                Name = "Parrot"
            };

            types.Add(type);

            type = new AnimalType
            {
                Id = 4,
                Name = "Rabbit"
            };

            types.Add(type);

            type = new AnimalType
            {
                Id = 5,
                Name = "Hamster"
            };

            types.Add(type);

            type = new AnimalType
            {
                Id = 6,
                Name = "Fish"
            };

            types.Add(type);

            return types;
        }
    
    }
}
