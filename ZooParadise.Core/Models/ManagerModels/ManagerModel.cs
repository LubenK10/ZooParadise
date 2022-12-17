using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooParadise.Core.Models.ManagerModels
{
    using static ZooParadise.Infrastructure.Data.Constants.ManagerConstants;
    public class ManagerModel
    {
        [Required]
        [Phone]
        [StringLength(PhoneNumberMaxLength, MinimumLength = PhoneNumberMinLength)]
        [Display(Name = "Phone Number")]
        [RegularExpression(PhoneNumberRegex)]
        public string PhoneNumber { get; set; } = null!;
    }
}
