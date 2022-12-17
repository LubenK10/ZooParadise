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
    using static ZooParadise.Infrastructure.Data.Constants.PetConstants;
    public class PetModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(NameMaxLength, MinimumLength = NameMinLength)]
        public string Name { get; set; } = null!;

        [Required]
        [Range(MinAge, MaxAge)]
        public int Age { get; set; }

        public int Gender { get; set; }

        [Required]
        [Column(TypeName = "money")]
        public decimal Price { get; set; }

        [Required]
        [DataType(DataType.ImageUrl)]
        public string ImageUrl { get; set; } = null!;

        public int AnimalType { get; set; }

        public int Colour { get; set; }

        public bool IsAdopted { get; set; }

        [Required]
        [StringLength(DescriptionMaxLenght, MinimumLength = DescriptionMinLenght)]
        public string Description { get; set; } = null!;

        public IEnumerable<AnimalTypeModel> AnimalTypes { get; set; } = new List<AnimalTypeModel>();

        public IEnumerable<ColourModel> Colours { get; set; } = new List<ColourModel>();

        public IEnumerable<GenderModel> Genders { get; set; } = new List<GenderModel>();
    }
}
