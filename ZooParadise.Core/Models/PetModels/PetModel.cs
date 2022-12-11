using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooParadise.Core.Models.EntityModels;

namespace ZooParadise.Core.Models.Pet
{
    public class PetModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = null!;

        [Required]
        public int Age { get; set; }

        public int Gender { get; set; }

        public decimal Price { get; set; }

        public string ImageUrl { get; set; } = null!;

        public int AnimalType { get; set; }

        public int Colour { get; set; }

        public bool IsAdopted { get; set; }

        public string Description { get; set; } = null!;

        public IEnumerable<AnimalTypeModel> AnimalTypes { get; set; } = new List<AnimalTypeModel>();

        public IEnumerable<ColourModel> Colours { get; set; } = new List<ColourModel>();

        public IEnumerable<GenderModel> Genders { get; set; } = new List<GenderModel>();
    }
}
