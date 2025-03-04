using System.ComponentModel.DataAnnotations;

namespace CedarCreek.Models.Accounts
{
    public class ChangePasswordViewModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Enter Your Current Password")]
        public string CurrentPassword { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Type Your New Password")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm Your Password")]
        [Compare("NewPassword", ErrorMessage = "Password does not match")]
        public string ConfirmPassword { get; set; }
    }
}
