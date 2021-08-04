using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalShelter.Models
{
    public class Vet:BaseEntity
    {
        public string PWZNumber { get; set; }


        public virtual Employee Employee { get; set; }
        public virtual ICollection<Vet_Specialty> Vet_Specialties { get; set; }
        public virtual ICollection<VetVisit> VetVisits { get; set; }
    }
}
