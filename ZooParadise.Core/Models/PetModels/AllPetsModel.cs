using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooParadise.Core.Models.EntityModels;

namespace ZooParadise.Core.Models.Pet
{
    public class AllPetsModel
    {
        public const int PetsPerPage = 3;

        public string? AnimalType { get; set; }

        public string? SearchTerm { get; set; }

        public PetSorting Sorting { get; set; }

        public int CurrentPage { get; set; }

        public int TotalPetCount { get; set; }

        public IEnumerable<string> AnimalTypes { get; set; } = Enumerable.Empty<string>();

        public IEnumerable<PetServiceModel> Pets { get; set; } = Enumerable.Empty<PetServiceModel>();
    }
}
