using System.ComponentModel.DataAnnotations;

namespace Cat.Models.Accounts
{
    public class AddPasswordViewModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Type new kitty password here:")]
        public string NewPassword { get; set; }
        [DataType(DataType.Password)]
        [Display(Name = "Type it again plizzz:")]
        [Compare("NewPassword", ErrorMessage ="The new kitty password and its confirmation do not match. Please try again")]
        public string ConfirmPassword { get; set;}
    }
}
