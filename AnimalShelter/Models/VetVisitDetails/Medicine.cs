using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalShelter.Models
{
    public class Medicine
    {
        public int IdMedicine { get; set; }
        public string Name { get; set; }
       

        public virtual ICollection<PrescribedMedicine> PrescribedMedicines { get; set; }
    }
}
