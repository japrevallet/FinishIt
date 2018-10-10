using FinishIt.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FinishIt.ViewModel
{
    public class ReadStateViewModel
    {
        [Required]
        [Display(Name="StateID")]
        public int StateID { get; set; }

        public List<SelectListItem> States { get; set; }

        public ReadStateViewModel(IEnumerable<State> states)
        {
            States = new List<SelectListItem>();
            foreach (var state in states)
            {
                States.Add(new SelectListItem
                {
                    Value = state.StateID.ToString(),
                    Text = state.StateName
                });
            }
        }
        public ReadStateViewModel() { }
    }
}
