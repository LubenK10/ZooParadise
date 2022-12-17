using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooParadise.Infrastructure.Data.Entities
{
    using static Data.Constants.PetConstants;
    public class Pet
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(NameMaxLength, MinimumLength = NameMinLength)]
        public string Name { get; set; } = null!;

        [Required]
        [Range(MinAge,MaxAge)]
        public int Age { get; set; }

        public int GenderId { get; set; }

        [ForeignKey(nameof(GenderId))]
        public Gender Gender { get; set; }

        [Required]
        [Column(TypeName = "money")]
        [Precision(18, 2)]
        public decimal Price { get; set; }

        [Required]
        [DataType(DataType.ImageUrl)]
        public string ImageUrl { get; set; } = null!;

        public int AnimalTypeId { get; set; }

        [ForeignKey(nameof(AnimalTypeId))]
        public AnimalType AnimalType { get; set; }

        public int ColourId { get; set; }

        [ForeignKey(nameof(ColourId))]
        public Colour Colour { get; set; }

        [Required]
        [StringLength(DescriptionMaxLenght, MinimumLength = DescriptionMinLenght)]
        public string Description { get; set; } = null!;

        public bool IsAvailable { get; set; } = true;

        [Required]
        public int ManagerId { get; set; }

        [ForeignKey(nameof(ManagerId))]
        public Manager Manager { get; set; }

        public string? AdopterId { get; set; }

        [ForeignKey(nameof(AdopterId))]
        public User? Adopter { get; set; }

    }
}
