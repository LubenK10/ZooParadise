using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooParadise.Core.Models.ManagerModels
{
    public class ManagerServiceModel
    {
        public string Phone { get; set; } = null!;

        public string Email { get; set; } = null!;
    }
}
