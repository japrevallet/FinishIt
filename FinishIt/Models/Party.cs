using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FinishIt.Models
{
    public class Party
    {
        [Key]
        public int PartyID { get; set; }
        public string PartyName { get; set; }

        public IList<Senator> Senators { get; set; }
    }
}
