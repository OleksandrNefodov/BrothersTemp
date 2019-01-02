using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Brothers.Repository.ServiceMapping.Entities
{
    public class AuthenticationView : AuthenticationViewBase
    {
        [Required(ErrorMessage = "Please repeat password")]
        [Compare("Password", ErrorMessage = "Passwords don't match")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        public string PasswordConfirm { get; set; }
    }
}