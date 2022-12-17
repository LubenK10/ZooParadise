using Microsoft.AspNetCore.Identity;
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
    using static Data.Constants.UserConstants;
    public class User : IdentityUser
    {
        [StringLength(UserFirstNameMaxLength, MinimumLength = UserFirstNameMinLength)]
        public string? FirstName { get; set; }

        [StringLength(UserLastNameMaxLength, MinimumLength = UserLastNameMinLength)]
        public string? LastName { get; set; }

        public bool IsActive { get; set; } = true;

    }
}
