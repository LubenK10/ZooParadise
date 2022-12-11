using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooParadise.Infrastructure.Data.Entities
{
    public class User : IdentityUser
    {
        public User()
        {
            UsersPets = new List<UsersPets>();
        }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public bool IsActive { get; set; } = true;

     //   [Column(TypeName = "money")]
     //   [Precision(18, 2)]
     //   public decimal Balance { get; set; } = 1000;

        public ICollection<UsersPets> UsersPets { get; set; }
    }
}
