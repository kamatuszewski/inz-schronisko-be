using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalShelter.Models
{
    public class Medicine:BaseEntity
    {
        [MaxLength(255)]
        public string Name { get; set; }
       

        public virtual ICollection<PrescribedMedicine> PrescribedMedicines { get; set; }
    }
}
