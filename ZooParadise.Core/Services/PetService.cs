using Microsoft.EntityFrameworkCore;
using ZooParadise.Core.Contracts;
using ZooParadise.Core.Models.EntityModels;
using ZooParadise.Core.Models.Pet;
using ZooParadise.Infrastructure.Data;
using ZooParadise.Infrastructure.Data.Common;
using ZooParadise.Infrastructure.Data.Entities;

namespace ZooParadise.Core.Services
{
    public class PetService : IPetService
    {

        private readonly ApplicationDbContext data;

        public PetService(ApplicationDbContext _data)
        {
            data = _data;
        }


        public async Task<PetQueryModel> All(string? animalType = null,
            string? colour = null,
            string? gender = null,
            string? searchTerm = null,
            PetSorting sorting = PetSorting.Newest,
            int currentPage = 1,
            int petsPerPage = 1)
        {
            var result = new PetQueryModel();
            var pets = data.Pets
                .Where(h => h.IsAvailable);

            if (string.IsNullOrEmpty(animalType) == false)
            {
                pets = pets
                    .Where(h => h.AnimalType.Name == animalType);
            }

            if (string.IsNullOrEmpty(colour) == false)
            {
                pets = pets
                    .Where(h => h.Colour.Name == colour);
            }

            if (string.IsNullOrEmpty(gender) == false)
            {
                pets = pets
                    .Where(h => h.Gender.Name == gender);
            }

            if (string.IsNullOrEmpty(searchTerm) == false)
            {
                searchTerm = $"%{searchTerm.ToLower()}%";

                pets = pets
                    .Where(h => EF.Functions.Like(h.Name.ToLower(), searchTerm) ||
                        EF.Functions.Like(h.AnimalType.Name.ToLower(), searchTerm));
            }



            pets = sorting switch
            {
                PetSorting.Price => pets
                    .OrderBy(h => h.Price),
                PetSorting.Alphabetically => pets
                    .OrderBy(h => h.Name),
                _ => pets.OrderByDescending(h => h.Id)
            };

            result.Pets = await pets
               .Skip((currentPage) * petsPerPage)
                .Take(petsPerPage)
                .Select(h => new PetModel()
                {
                    Id = h.Id,
                    ImageUrl = h.ImageUrl,
                    Name = h.Name,
                    Description = h.Description,
                    Age = h.Age,
                    Price = h.Price,
                    AnimalType = h.AnimalTypeId,
                    Colour = h.ColourId,
                    Gender = h.GenderId
                })
                .ToListAsync();

            result.PetsCount = await pets.CountAsync();

            return result;
        }

        public async Task<IEnumerable<AnimalTypeModel>> AllAnimalTypes()
        {
            return await data.AnimalTypes
                .OrderBy(c => c.Name)
                .Select(c => new AnimalTypeModel()
                {
                    Id = c.Id,
                    Name = c.Name,
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<ColourModel>> AllColours()
        {
            return await data.Colours
                .OrderBy(c => c.Name)
                .Select(c => new ColourModel()
                {
                    Id = c.Id,
                    Name = c.Name,
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<GenderModel>> AllGenders()
        {
            return await data.Genders
                .OrderBy(c => c.Name)
                .Select(c => new GenderModel()
                {
                    Id = c.Id,
                    Name = c.Name,
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<string>> AllAnimalTypesNames()
        {
            return await data.AnimalTypes
                .Select(c => c.Name)
                .Distinct()
                .ToListAsync();
        }

        public async Task<IEnumerable<string>> AllColoursNames()
        {
            return await data.Colours
                .Select(c => c.Name)
                .Distinct()
                .ToListAsync();
        }

        public async Task<IEnumerable<string>> AllGendersNames()
        {
            return await data.Genders
                .Select(c => c.Name)
                .Distinct()
                .ToListAsync();
        }

        public async Task<IEnumerable<PetServiceModel>> AllPetsByManagerId(int id)
        {
            return await data.Pets
               .Where(p => p.IsAvailable)
               .Where(p => p.ManagerId == id)
               .Select(p => new PetServiceModel()
               {
                   Id = p.Id,
                   ImageUrl = p.ImageUrl,
                   Name = p.Name,
                   Age = p.Age,
                   Price = p.Price,
                   AnimalType = p.AnimalType.Name,
                   Description = p.Description,
                   Gender = p.Gender.Name,
                   IsAdopted = p.AdopterId != null,
                   Colour = p.Colour.Name
               })
               .ToListAsync();
        }

        public async Task<IEnumerable<PetServiceModel>> AllPetsByUserId(string userId)
        {
            return await data.Pets
                .Where(p => p.AdopterId == userId)
                .Where(p => p.IsAvailable)
                .Select(p => new PetServiceModel()
                {
                    Id = p.Id,
                    ImageUrl = p.ImageUrl,
                    Name = p.Name,
                    Age = p.Age,
                    Price = p.Price,
                    AnimalType = p.AnimalType.Name,
                    Description = p.Description,
                    Gender = p.Gender.Name,
                    Colour = p.Colour.Name,
                    IsAdopted = p.AdopterId != null
                })
                .ToListAsync();
        }

        public async Task<int> Create(AddPetModel model, int managerId)
        {
            var pet = new Pet()
            {
                Id = model.Id,
                ImageUrl = model.ImageUrl,
                Name = model.Name,
                Age = model.Age,
                Price = model.Price,
                AnimalTypeId = model.AnimalType,
                Description = model.Description,
                GenderId = model.Gender,
                ColourId = model.Colour,
                ManagerId = managerId
            };

            await data.AddAsync(pet);
            await data.SaveChangesAsync();


            return pet.Id;
        }

        public async Task<bool> Exists(int id)
        {
            return data.Pets
                 .Any(p => p.Id == id);
        }

        public async Task<DetailsPetModel> PetDetailsById(int id)
        {
            return await data.Pets
              .Where(p => p.IsAvailable)
              .Where(h => h.Id == id)
              .Select(h => new DetailsPetModel()
              {
                  Age = h.Age,
                  Description = h.Description,
                  Id = id,
                  ImageUrl = h.ImageUrl,
                  IsAdopted = h.AdopterId != null,
                  Price = h.Price,
                  Name = h.Name,
                  AnimalType = h.AnimalType.Name,
                  Colour = h.Colour.Name,
                  Gender = h.Gender.Name,
                  Manager = new Models.ManagerModels.ManagerServiceModel()
                  {
                      Email = h.Manager.User.Email,
                      Phone = h.Manager.Phone
                  }

              })
              .FirstAsync();
        }

        public async Task<IEnumerable<PetHomeModel>> LastThreePets()
        {
            return await data.Pets
                .Where(p => p.IsAvailable)
                .Select(x => new PetHomeModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                    ImageUrl = x.ImageUrl
                })
                .OrderByDescending(i => i.Id)
                .Take(3)
                .ToListAsync();
        }

        public async Task Edit(int petId, PetModel model)
        {
            var pet = data.Pets.FirstOrDefault(c => c.Id == petId);

            pet.Description = model.Description;
            pet.ImageUrl = model.ImageUrl;
            pet.Price = model.Price;
            pet.Name = model.Name;
            pet.Age = model.Age;
            pet.AnimalTypeId = model.AnimalType;
            pet.ColourId = model.Colour;
            pet.GenderId = model.Gender;

            await data.SaveChangesAsync();
        }

        public async Task<bool> HasManagerWithId(int petId, string currentUserId)
        {
            bool result = false;

            var pet = await data.Pets
                .Where(h => h.IsAvailable)
                .Where(h => h.Id == petId)
                .Include(h => h.Manager)
                .FirstOrDefaultAsync();

            if (pet?.Manager != null && pet.Manager.UserId == currentUserId)
            {
                result = true;
            }

            return result;
        }

        public async Task<int> GetAnimalTypeId(int petId)
        {
            return data.Pets.FirstOrDefault(c => c.Id == petId).AnimalTypeId;
        }

        public async Task<int> GetColourId(int petId)
        {
            return data.Pets.FirstOrDefault(c => c.Id == petId).ColourId;
        }

        public async Task<int> GetGenderId(int petId)
        {
            return data.Pets.FirstOrDefault(c => c.Id == petId).GenderId;
        }

        public async Task Delete(int petId)
        {
            var pet = data.Pets.FirstOrDefault(c => c.Id == petId);
            pet.IsAvailable = false;

            await data.SaveChangesAsync();
        }

        public async Task<bool> IsAdopted(int petId)
        {
             var pet = data.Pets.FirstOrDefault(c => c.Id == petId);
             return pet.AdopterId != null;
        }

        public async Task<bool> IsAdoptedByUser(int petId, string currentUserId)
        {
            bool result = false;
            var pet = await data.Pets
                .Where(h => h.IsAvailable)
                .Where(h => h.Id == petId)
                .FirstOrDefaultAsync();

            if (pet != null && pet.AdopterId == currentUserId)
            {
                result = true;
            }

            return result;
        }

        public async Task Adopt(int petId, string currentUserId)
        {
            var pet = data.Pets.FirstOrDefault(c => c.Id == petId);

            if (pet != null && pet.AdopterId != null)
            {
                throw new ArgumentException("Pet is already adopted");
            }
            if (pet == null)
            {
                throw new ArgumentException("Pet can not be found");
            }

            pet.AdopterId = currentUserId;

            await data.SaveChangesAsync();
        }

        public async Task Leave(int petId)
        {
            var pet = data.Pets.FirstOrDefault(c => c.Id == petId);

            if (pet == null)
            {
                throw new ArgumentException("Pet can not be found");
            }

            pet.AdopterId = null;

            await data.SaveChangesAsync();
        }
    }
}
