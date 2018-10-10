using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinishIt.ViewModel
{
    public class ResetPasswordViewModel
    {
        //add validation 
        public string UserId { get; set; }
        public string Token { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }

    }
}
