using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ZooParadise.Infrastructure.Data.Configuration;
using ZooParadise.Infrastructure.Data.Entities;

namespace ZooParadise.Infrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        private bool seedDb;
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, bool seed = true)
            : base(options)
        {
            if (Database.IsRelational())
            {
                Database.Migrate();
            }
            else
            {
                Database.EnsureCreated();
            }

            this.seedDb = seed;
        }

        public DbSet<Pet> Pets { get; set; }

        public DbSet<Colour> Colours { get; set; }

        public DbSet<Gender> Genders { get; set; }

        public DbSet<Manager> Managers { get; set; }

        public DbSet<AnimalType> AnimalTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            if (seedDb)
            {
                builder.ApplyConfiguration(new UserConfiguration());
                builder.ApplyConfiguration(new ManagerConfiguration());
                builder.ApplyConfiguration(new ColourConfiguration());
                builder.ApplyConfiguration(new AnimalTypesConfiguration());
                builder.ApplyConfiguration(new GenderConfiguation());
                builder.ApplyConfiguration(new PetConfiguration());
            }

            base.OnModelCreating(builder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
            base.OnConfiguring(optionsBuilder);
        }
    }
}