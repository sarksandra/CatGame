using System.ComponentModel.DataAnnotations;

namespace CedarCreek.Models.Accounts
{
    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Your Password")]
        [Compare("Password", ErrorMessage = "Password does not match")]
        public string ConfirmPassword { get; set; }
        public string City { get; set; }
        public bool ProfileType { get; set; } // admin = true
    }
}
