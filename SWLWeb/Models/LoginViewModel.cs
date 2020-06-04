﻿using System.ComponentModel.DataAnnotations;

namespace SWLWeb.Models
{
    public class LoginViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email Address")]
        public string Email { get; set; }
    }
}