using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooParadise.Core.Models.ManagerModels
{
    public class ManagerModel
    {
        [Required]
        [Phone]
        [StringLength(15, MinimumLength = 7)]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; } = null!;
    }
}
