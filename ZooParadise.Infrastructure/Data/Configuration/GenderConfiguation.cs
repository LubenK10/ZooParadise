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
    public class GenderConfiguation : IEntityTypeConfiguration<Gender>
    {
        public void Configure(EntityTypeBuilder<Gender> builder)
        {
            builder.HasData(CreateGenderTypes());
        }

        private List<Gender> CreateGenderTypes()
        {
            var genders = new List<Gender>();

            var gender = new Gender()
            {
                Id = 1,
                Name = "Male"
            };

            genders.Add(gender);

            gender = new Gender()
            {
                Id = 2,
                Name = "Female"
            };

            genders.Add(gender);


            return genders;
        }
    }
}