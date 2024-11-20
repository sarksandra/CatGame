using System.ComponentModel.DataAnnotations;

namespace Cat.Models.Accounts
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
    }
}
