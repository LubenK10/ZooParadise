using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooParadise.Core.Models.EntityModels;
using ZooParadise.Core.Models.Pet;

namespace ZooParadise.Core.Contracts
{
    public interface IPetService
    {
        Task<IEnumerable<PetHomeModel>> LastThreeHouses();

        Task<IEnumerable<AnimalTypeModel>> AllAnimalTypes();

        Task<IEnumerable<GenderModel>> AllGenders();

        Task<IEnumerable<ColourModel>> AllColours();

        Task<int> Create(AddPetModel model, int managerId);

        Task<PetQueryModel> All(
            string? animalType = null,
            string? searchTerm = null,
            PetSorting sorting = PetSorting.Newest,
            int currentPage = 1,
            int petsPerPage = 1);

        Task<IEnumerable<string>> AllAnimalTypesNames();

        Task<IEnumerable<string>> AllGendersNames();

        Task<IEnumerable<string>> AllColoursNames();
        
        Task<IEnumerable<PetServiceModel>> AllPetsByManagerId(int id);

        Task<IEnumerable<PetServiceModel>> AllPetsByUserId(string userId);

        Task<DetailsPetModel> HouseDetailsById(int id);

        Task<bool> Exists(int id);
   //
   //    Task Edit(int houseId, HouseModel model);
   //
   //    Task<bool> HasAgentWithId(int houseId, string currentUserId);
   //
   //    Task<int> GetHouseCategoryId(int houseId);
   //
   //    Task Delete(int houseId);
   //
   //    Task<bool> IsRented(int houseId);
   //
   //    Task<bool> IsRentedByUserWithId(int houseId, string currentUserId);
   //
   //    Task Rent(int houseId, string currentUserId);
   //
   //    Task Leave(int houseId);
    }
}
