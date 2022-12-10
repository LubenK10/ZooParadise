﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooParadise.Core.Models.Pet
{
    public class PetQueryModel
    {
        public PetQueryModel()
        {
            Pets = new List<PetServiceModel>();
        }

        public int PetsCount { get; set; }

        public IEnumerable<PetServiceModel> Pets { get; set; }
    }
}
