using System.ComponentModel.DataAnnotations;

namespace CedarCreek.Models.Accounts
{
    public class AddPasswordViewModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name  = "Enter New Password")]
        public string NewPassword { get; set; }
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Your Password")]
        [Compare("NewPassword", ErrorMessage = "Password does not match")]
        public string ConfirmPassword { get; set; }
    }
}
