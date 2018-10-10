using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FinishIt.ViewModel
{
    public class RegisterViewModel
    {
        //add validations
        [Required, Display(Name = "User Name")]
        public string UserName { get; set; }
        [Required, EmailAddress]
        public string Email { get; set; }
        [Required, ]
        public string Password { get; set; }
        //add Compare validation
        [Required, Display(Name = "Confirm Password")]
        public string ConfirmPassword { get; set; }
    }
}
