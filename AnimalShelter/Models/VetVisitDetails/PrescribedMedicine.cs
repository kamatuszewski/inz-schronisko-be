using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalShelter.Models
{
    public class PrescribedMedicine
    {
        public int VisitId { get; set; }
        public int MedicineId { get; set; }
        public int Amount { get; set; }

        public virtual Medicine Medicine { get; set; }    
        public virtual VetVisit VetVisit { get; set; }    
    }
}

