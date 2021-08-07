using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalShelter.Models
{
    public class PerformedTreatment
    {
        public int VisitId { get; set; }
        public int TreatmentId { get; set; }

        public virtual Treatment Treatment { get; set; }    
        public virtual VetVisit VetVisit { get; set; }    
    }
}

