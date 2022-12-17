using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooParadise.Core.Models.PetModels
{
    using static ZooParadise.Infrastructure.Data.Constants.PetConstants;
    public class DeletePetModel
    {
        [Required]
        [StringLength(NameMaxLength, MinimumLength = NameMinLength)]
        public string Name { get; set; } = null!;

        [Required]
        [Range(MinAge, MaxAge)]
        public int Age { get; set; }

        [StringLength(ImageUrlMax, MinimumLength = ImageUrlMin)]
        public string ImageUrl { get; set; } = null!;
    }
}
