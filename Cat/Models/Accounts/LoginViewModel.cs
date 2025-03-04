using System.ComponentModel.DataAnnotations;

namespace CedarCreek.Models.Accounts
{
    public class LoginViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name = "Remember This Account?")]
        public bool RememberMe { get; set; }
        public string? returnURL { get; set; }
   
    }
}
