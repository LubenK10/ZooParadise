using ZooParadise.Core.Models.Pet;

namespace ZooParadise.Areas.Admin.Models
{
    public class MyPetsModel
    {
        public IEnumerable<PetServiceModel> AddedPets{ get; set; }
           = new List<PetServiceModel>();

        public IEnumerable<PetServiceModel> AdoptedPets { get; set; }
            = new List<PetServiceModel>();
    }
}
