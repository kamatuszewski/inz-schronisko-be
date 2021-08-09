using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalShelter.Models
{
    public class AdoptionOfficeWorker:BaseEntity
    {
        public int AssignedSpeciesId { get; set; }

        public Species AssignedSpecies { get; set; } 
        public virtual Employee Employee { get; set; }
        public virtual ICollection<Adoption> Adoptions { get; set; }
    }
}
