using FinishIt.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FinishIt.ViewModel
{
    public class AllPartySenatorsViewModel
    {
        [Required]
        [Display(Name = "PartyID")]
        public int PartyID { get; set; }

        public List<SelectListItem> AllParties { get; set; }

        public AllPartySenatorsViewModel(IEnumerable<Party> Parties)
        {
            AllParties = new List<SelectListItem>();

            foreach (var party in Parties)
            {
                AllParties.Add(new SelectListItem
                {
                    Value = party.PartyID.ToString(),
                    Text = party.PartyName
                });
            }
        }
        public AllPartySenatorsViewModel() { }
    }
}
