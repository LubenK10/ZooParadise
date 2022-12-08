using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ZooParadise.Infrastructure.Data.Entities;

namespace ZooParadise.Infrastructure.Data.Configuration
{
    public class ColourConfiguration : IEntityTypeConfiguration<Colour>
    {
        public void Configure(EntityTypeBuilder<Colour> builder)
        {
            builder.HasData(CreateColours());
        }


        private List<Colour> CreateColours()
        {
            var petColours = new List<Colour>();

            var colour = new Colour()
            {
                Id = 1,
                Name = "Black"
            };

            petColours.Add(colour);

            colour = new Colour()
            {
                Id = 2,
                Name = "White"
            };

            petColours.Add(colour);

            colour = new Colour()
            {
                Id = 3,
                Name = "Grey"
            };

            petColours.Add(colour);

            colour = new Colour()
            {
                Id = 4,
                Name = "Brown"
            };

            petColours.Add(colour);

            colour = new Colour()
            {
                Id = 5,
                Name = "Golden"
            };

            petColours.Add(colour);

            colour = new Colour()
            {
                Id = 6,
                Name = "Red"
            };

            petColours.Add(colour);

            colour = new Colour()
            {
                Id = 7,
                Name = "Blue"
            };

            petColours.Add(colour);


            colour = new Colour()
            {
                Id = 8,
                Name = "Orange"
            };


            petColours.Add(colour);

            colour = new Colour()
            {
                Id = 9,
                Name = "Colurful"
            };

            petColours.Add(colour);

            return petColours;
        }
    }
}