using System.ComponentModel.DataAnnotations;

namespace Cat.Models.Accounts
{
    public class LoginViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name = "Remeber this account?")]
        public string RemeberMe { get; set; }
        public string? ReturnURL { get; set; }
    }
}
