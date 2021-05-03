using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalShelter.Domain.Models
{
    public class PrescribedMedicine
    {
        public int IdMedicine { get; set; }
        public int IdVisit { get; set; }
        public int Amount { get; set; }

        public virtual Medicine Medicine { get; set; }    
        public virtual VetVisit VetVisit { get; set; }    
    }
}

