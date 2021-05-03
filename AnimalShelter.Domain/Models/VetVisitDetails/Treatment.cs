using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalShelter.Domain.Models
{
    public class Treatment
    {
        public int IdTreatment { get; set; }
        public string Name { get; set; }
       

        public virtual ICollection<PerformedTreatment> PerformedTreatments { get; set; }

    }
}
