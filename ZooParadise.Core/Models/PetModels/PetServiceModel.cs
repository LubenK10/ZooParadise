using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooParadise.Infrastructure.Data.Entities;

namespace ZooParadise.Core.Models.Pet
{
    public class PetServiceModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = null!;

        [Required]
        public int Age { get; set; }

        public int Gender { get; set; }

        [Required]
        [Column(TypeName = "money")]
        [Precision(18, 2)]
        public decimal Price { get; set; }

        [Required]
        [DataType(DataType.ImageUrl)]
        public string ImageUrl { get; set; } = null!;

        public int AnimalType { get; set; }

        public int Colour { get; set; }

        [Required]
        public string Description { get; set; } = null!;

        [Required]
        public int ManagerId { get; set; }

        public bool IsAdopted { get; set; }

    }
}
