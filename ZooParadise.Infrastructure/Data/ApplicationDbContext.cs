﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ZooParadise.Infrastructure.Data.Configuration;
using ZooParadise.Infrastructure.Data.Entities;

namespace ZooParadise.Infrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Pet> Pets { get; set; }

        public DbSet<Colour> Colours { get; set; }

        public DbSet<Gender> Genders { get; set; }

        public DbSet<Manager> Managers { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<UsersPets>()
                 .HasKey(x => new { x.PetId, x.UserId });


            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new ManagerConfiguration());
            builder.ApplyConfiguration(new ColourConfiguration());
            builder.ApplyConfiguration(new AnimalTypesConfiguration());
            builder.ApplyConfiguration(new GenderConfiguation());
            builder.ApplyConfiguration(new PetConfiguration());

            base.OnModelCreating(builder);
        }
    }
}