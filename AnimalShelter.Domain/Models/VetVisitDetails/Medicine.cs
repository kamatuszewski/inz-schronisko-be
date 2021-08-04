using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalShelter.Domain.Models
{
    public class Medicine:BaseEntity
    {
        public string Name { get; set; }
       

        public virtual ICollection<PrescribedMedicine> PrescribedMedicines { get; set; }
    }
}
