using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalShelter.Models
{
    public class AdoptionOfficeWorker
    {

        public int IdEmployee { get; set; }
        public int IdSpecies { get; set; }


        public int AssignedSpecies { get; set; } //to be re-named or removed?
        public virtual Employee Employee { get; set; }
        public virtual ICollection<Adoption> Adoptions { get; set; }
    }
}
