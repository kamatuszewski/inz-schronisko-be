using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalShelter.Models
{
    public class Specialty:BaseEntity
    {
        public string Name { get; set; }
        public int MinSalary { get; set; }


        public virtual ICollection<Vet_Specialty> Vet_Specialties { get; set; }
    }
}
