using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FinishIt.ViewModel
{
    public class AddStateViewModel
    {
        public int StateID { get; set; }
        [Required]
        [Display(Name = "New State Name")]
        public string StateName { get; set; }
    }
}
