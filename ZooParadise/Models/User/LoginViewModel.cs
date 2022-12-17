using System.ComponentModel.DataAnnotations;

namespace ZooParadise.Models.User
{
    using static ZooParadise.Infrastructure.Data.Constants.UserConstants;
    public class LoginViewModel
    {
        [Required]
        [StringLength(UsernameMaxLength, MinimumLength = UsernameMinLength)]
        public string UserName { get; set; } = null!;


        [Required]
        [DataType(DataType.Password)]
        [StringLength(PasswordMaxLength, MinimumLength = PasswordMinLength)]
        public string Password { get; set; } = null!;

    }
}
