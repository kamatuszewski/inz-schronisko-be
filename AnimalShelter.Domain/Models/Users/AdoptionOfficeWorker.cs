using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalShelter.Domain.Models
{
    public class AdoptionOfficeWorker:BaseEntity
    {

        public int IdEmployee { get; set; }
        public int IdSpecies { get; set; }


        public int AssignedSpecies { get; set; } //to be re-named or removed?
        public virtual Employee Employee { get; set; }
        public virtual ICollection<Adoption> Adoptions { get; set; }
    }
}
