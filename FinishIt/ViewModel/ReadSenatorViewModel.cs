using FinishIt.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FinishIt.ViewModel
{
    public class ReadSenatorViewModel
    {
        //Not currently using for anything
        //basically exactly the same as Models.Senator

        [Key]
        public int SenatorID { get; set; }
        public string SenatorName { get; set; }

        public int Age { get; set; }
        public string Occupation { get; set; }
        public DateTime YearsServed { get; set; }
        public string SeatUp { get; set; }

        [ForeignKey("State")]
        public int StateID { get; set; }
        public State State { get; set; }

        [ForeignKey("Party")]
        public int PartyID { get; set; }
        public Party Party { get; set; }
    }
}
