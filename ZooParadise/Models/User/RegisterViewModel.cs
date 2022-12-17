using System.ComponentModel.DataAnnotations;

namespace ZooParadise.Models.User
{
    public class RegisterViewModel
    {
        [Required]
        [StringLength(20)]
        public string UserName { get; set; } = null!;

        [Required]
        [StringLength(60)]
        public string Email { get; set; } = null!;

        [Required]
        [DataType(DataType.Password)]
        [StringLength(60)]
        public string Password { get; set; } = null!;

        [Required]
        [Compare(nameof(Password))]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; } = null!;
    }
}
