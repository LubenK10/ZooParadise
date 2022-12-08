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
    public class ManagerConfiguration : IEntityTypeConfiguration<Manager>
    {
        public void Configure(EntityTypeBuilder<Manager> builder)
        {
            builder.HasData(CreateManager());
        }

        private Manager CreateManager()
        {
            var manager = new Manager()
            {
                Id = 1,
                Phone = "+359 89 887 6756",
                UserId = "3ccf3f38-c3da-44c2-b658-a2030620bd8e"
            };

            return manager;
        }
    }
}