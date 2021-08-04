using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalShelter.Models
{
    public class Species: BaseEntity
    {
        public string Name { get; set; }

        public virtual ICollection<Animal> Animals { get; set; }
        public virtual ICollection<AdoptionOfficeWorker> AdoptionOfficeWorkers { get; set; }
    }
}
