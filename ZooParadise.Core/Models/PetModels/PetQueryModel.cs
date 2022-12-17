using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooParadise.Core.Models.Pet
{
    public class PetQueryModel : PetModel
    {
        public PetQueryModel()
        {
            Pets = new List<PetModel>();
        }

        public int PetsCount { get; set; }

        public IEnumerable<PetModel> Pets { get; set; }
    }
}
