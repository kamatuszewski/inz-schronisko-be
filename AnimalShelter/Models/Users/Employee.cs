using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalShelter.Models
{
    public class Employee:BaseEntity
    {
        public DateTime HireDate { get; set; }
        public DateTime? QuitDate { get; set; }
        public int Salary { get; set; }

        public virtual Person Person { get; set; }
        public virtual ICollection<Vet> Vets { get; set; }
        public virtual ICollection<AdoptionOfficeWorker> AdoptionOfficeWorkers { get; set; }
    }
}
