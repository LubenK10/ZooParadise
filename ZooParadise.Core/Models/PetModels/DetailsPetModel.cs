using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooParadise.Core.Models.ManagerModels;

namespace ZooParadise.Core.Models.Pet
{
    public class DetailsPetModel : PetServiceModel
    {
        public ManagerServiceModel Manager { get; set; }
    }
}
