using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalShelter.Models
{
    public class Specialty:BaseEntity
    {
        [MaxLength(255)]
        public string Name { get; set; }
   //     public int MinSalary { get; set; }


        public virtual ICollection<Vet_Specialty> Vet_Specialties { get; set; }
    }
}
