using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Project.Models.ViewModel
{
    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Username")]
        [StringLength(16, ErrorMessage = "Error, username must be between 4 to 16 characters long", MinimumLength = 4)]
        public string UserName { get; set; }

        [Required]
        [StringLength(16, ErrorMessage = "Error, password must be between 8 to 16 characters long", MinimumLength = 8)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}