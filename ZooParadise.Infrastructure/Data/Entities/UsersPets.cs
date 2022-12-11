using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooParadise.Infrastructure.Data.Entities
{
    public class UsersPets
    {
        [Required]
        public string UserId { get; set; } = null!;
        public User User { get; set; } = null!;

        [Required]
        public int PetId { get; set; }
        public Pet Pet { get; set; } = null!;
    }
}
