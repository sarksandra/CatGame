﻿using System.ComponentModel.DataAnnotations;

namespace Cat.Models.Accounts
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
