using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooParadise.Core.Models.PetModels
{
    public class DeletePetModel
    {
        public string Name { get; set; } = null!;

        public int Age { get; set; }

        public string ImageUrl { get; set; } = null!;
    }
}
