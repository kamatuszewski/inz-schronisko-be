using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalShelter.Domain.Models
{
    public class Director
    {
        public int IdDirector { get; set; }

        public virtual Person Person { get; set; }
    }
}
