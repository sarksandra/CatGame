using System.ComponentModel.DataAnnotations;

namespace CedarCreek.Models.Accounts
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
