using System.ComponentModel.DataAnnotations;

namespace Cat.Models.Accounts
{
    public class ResetPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Display(Name = "Confirm your password by typing again: ")]
        [Compare("Password", ErrorMessage ="Password and its confirmation dos not match. please try again")]
        public string ConfirmPassword { get; set; }
        public string Token { get; set; }
    }
}
