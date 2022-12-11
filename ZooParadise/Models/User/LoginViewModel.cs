using System.ComponentModel.DataAnnotations;

namespace ZooParadise.Models.User
{
    public class LoginViewModel
    {
        [Required]
        [StringLength(20)]
        public string UserName { get; set; } = null!;


        [Required]
        [DataType(DataType.Password)]
        [StringLength(60)]
        public string Password { get; set; } = null!;

        [Required]
        public string ReturnUrl { get; set; } = null!;
    }
}
