using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooParadise.Core.Models.EntityModels;
using ZooParadise.Infrastructure.Data.Entities;

namespace ZooParadise.Core.Models.Pet
{
    using static ZooParadise.Infrastructure.Data.Constants.PetConstants;
    public class AddPetModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(NameMaxLength, MinimumLength = NameMinLength)]
        public string Name { get; set; } = null!;

        [Required]
        [Range(MinAge,MaxAge)]
        public int Age { get; set; }

        [Display(Name = "Gender")]
        public int Gender { get; set; }

        [Required]
        [Column(TypeName = "money")]
        public decimal Price { get; set; }

        [Required]
        [DataType(DataType.ImageUrl)]
        public string ImageUrl { get; set; } = null!;

        [Display(Name = "AnimalType")]
        public int AnimalType { get; set; }

        [Display(Name = "Colour")]
        public int Colour { get; set; }

        [Required]
        [StringLength(DescriptionMaxLenght, MinimumLength = DescriptionMinLenght)]
        public string Description { get; set; } = null!;

        public IEnumerable<ColourModel> Colours { get; set; }

        public IEnumerable<GenderModel> Genders { get; set; }

        public IEnumerable<AnimalTypeModel> AnimalTypes { get; set; }
    }
}
