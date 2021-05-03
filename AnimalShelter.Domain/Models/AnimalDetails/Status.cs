using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalShelter.Domain.Models
{
    public class Status
    {
        public int IdStatus { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }


        public virtual ICollection<Animal> Animals { get; set; }
    }
}
