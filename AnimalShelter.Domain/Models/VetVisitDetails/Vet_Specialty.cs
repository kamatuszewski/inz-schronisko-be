using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalShelter.Domain.Models
{
    public class Vet_Specialty:BaseEntity
    {
        public int IdSpecialty { get; set; }
        public DateTime ObtainingDate { get; set; }

        public virtual Vet Vet { get; set; }    
        public virtual Specialty Specialty { get; set; }    
    }
}
