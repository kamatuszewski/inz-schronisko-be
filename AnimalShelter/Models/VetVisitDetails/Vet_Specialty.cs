using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalShelter.Models
{
    public class Vet_Specialty:BaseEntity
    {
        public int IdVet { get; set; }
        public int IdSpecialty { get; set; }
        public DateTime ObtainingDate { get; set; }

        public virtual Vet Vet { get; set; }    
        public virtual Specialty Specialty { get; set; }    
    }
}
